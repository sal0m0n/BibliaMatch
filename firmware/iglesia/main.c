/******************************************************************************/
/* Files to Include                                                           */
/******************************************************************************/

#ifndef _XTAL_FREQ
#define _XTAL_FREQ 4000000 //4Mhz FRC internal osc
#define __delay_us(x) _delay((unsigned long)((x)*(_XTAL_FREQ/4000000.0)))
#define __delay_ms(x) _delay((unsigned long)((x)*(_XTAL_FREQ/4000.0)))
#endif



#include "system.h"        /* System funct/params, like osc/peripheral config */


volatile char bytesRecibidos = 0;

UARTMsg RX1_Buffer;
UARTMsg TX1_Buffer;

/******************************************************************************/
/* User Global Variable Declaration                                           */
/******************************************************************************/

/* i.e. uint8_t <variable_name>; */

/******************************************************************************/
/* Main Program                                                               */

/******************************************************************************/


void sci_Init()
{


    BRGH = 1;
    SPBRG = 25; // MANUAL SET 9600 BAUD 25


    TRISC7 = 1; /* USART NEEDS TRISC7 TO BE SET*/
    TRISC6 = 0; // this is for output

    TRISC2 = 1; // SW 1
    TRISC3 = 1; // SW 2

    SYNC = 0; /* asynchronous */
    SPEN = 1; /* enable serial port pins */
    CREN = 0;
    CREN = 1; /* enable reception */

    TXIE = 1; /* disable tx interrupts */
    RCIE = 1; /* ENABLE (0)disable rx interrupts */
    TX9 = 0; //ninebits?1:0; /* 8- or 9-bit transmission */
    RX9 = 0; // ninebits?1:0; /* 8- or 9-bit reception */



    PIR1 = 0; /* clear any pending interrupts */
    PEIE = 1; /* enable perhipheral interrupts */
    GIE = 1; /* global interrupts enabled */

    /* perform other setup */

}

bank2 unsigned char lrc, xx, more;
bank2 int ii, j, count;

void sendBuf(char *buf, int len)
{

    TX1_Buffer.buff[0] = 0x02;
    memcpy(TX1_Buffer.buff + 1, buf, len);
    TX1_Buffer.buff[len + 1] = 0x03;
    TX1_Buffer.nBytes = len + 2;

    TXEN = 1; /* enable the transmitter */

}

void sendChar(char cChar)
{

    TX1_Buffer.buff[0] = cChar;
    TX1_Buffer.nBytes = 1;

    TXEN = 1; /* enable the transmitter */

}

uint8_t main(void)
{
    /* Configure the oscillator for the device */
    ConfigureOscillator();
    TRISB = 0x00;

    INTCON = 0XC0; // GLOBAL INT SET, peripheral int set
    PIE1 = 0X00; // TIMER1 INT FLAG SET
    // Rx, Tx flag set
    RCIE = 1;

    /* Initialize I/O and Peripherals for application */
    InitApp();

    sci_Init();

    /* TODO <INSERT USER APPLICATION CODE HERE> */
    LED1 = 1;
    LED2 = 1;

    Estado = REPOSO;
    long timer = 0;
    int timeout = 10;
    char localBuf[5];

    

    while (1)
    {



        if (bytesRecibidos)
        {
            if (RX1_Buffer.buff[1] == 'R') //Reposo
            {
                sendChar(0x06);
                LED1 = 0;
                LED2 = 0;

                Estado = REPOSO;
            }
            else if (RX1_Buffer.buff[1] == 'P' ) // Pulsador
            {

                if ((SW1 == 1) || (SW2 == 1)) // adelantado
                {
                    if (SW1 == 1)
                    {
                        localBuf[0] = '3';
                        sendBuf(localBuf, 1);
                        LED1 = 1;
                        LED2 = 0;
                        Estado = REPOSO;
                    }
                    else if (SW2 == 1)
                    {
                        localBuf[0] = '4';
                        sendBuf(localBuf, 1);
                        LED1 = 0;
                        LED2 = 1;
                        Estado = REPOSO;
                    }
                }
                else
                {


                Estado = PULSADOR;
                LED1 = 0;
                LED2 = 0;
                TMR1 = 64535;
                timer = timeout;
                OpenTimer1();

                }
            }
            else if (RX1_Buffer.buff[1] == 'L')   // Cambio en LED
            {
                if((RX1_Buffer.buff[2] < 0x34)&&(RX1_Buffer.buff[2] > 0x29) && (RX1_Buffer.nBytes ==  4))
                {
                    if (RX1_Buffer.buff[2] == '0') // Apaga LEDS
                    {
                        LED1 = 0;
                        LED2 = 0;
                    }
                    if (RX1_Buffer.buff[2] == '1') // Enciendo LED1
                    {
                        LED1 = 1;
                        LED2 = 0;
                    }
                    if (RX1_Buffer.buff[2] == '2') // Enciendo LED2
                    {
                        LED1 = 0;
                        LED2 = 1;
                    }
                    if (RX1_Buffer.buff[2] == '3') // Enciendo ambos LEDS
                    {
                        LED1 = 1;
                        LED2 = 1;
                    }

                    sendChar(0x06); //ACK
                }

                else
                {
                    sendChar(0x15); //NAK
                }

            }
            else if ((RX1_Buffer.buff[1] == 'C') && (RX1_Buffer.nBytes == 5)) // Config
            {
                if ((RX1_Buffer.buff[2] < 0x40) && (RX1_Buffer.buff[2] > 0x29) && (RX1_Buffer.buff[3] < 0x40) && (RX1_Buffer.buff[3] > 0x29))
                {
                    int aux;
                    char num[3];
                    num[0] = RX1_Buffer.buff[2];
                    num[1] = RX1_Buffer.buff[3];
                    num[2] = 0;

                    aux = atoi(num);
                    if ((aux > 0) && (aux < 20))
                    {
                        timeout = aux;
                        sendChar(0x06); //ACK
                    }
                    else
                    {
                        sendChar(0x15); //NAK
                    }
                }
                else
                {
                    sendChar(0x15); //NAK
                }

            }
            else
            {
                sendChar(0x15); //NAK Comando no soportado
            }

            bytesRecibidos = 0;
            memset(RX1_Buffer.buff,0,20);
        }

        switch (Estado)
        {
        case REPOSO:

            
            break;

        case PULSADOR:

            if (SW1 == 1)
            {
                localBuf[0] = '1';
                sendBuf(localBuf, 1);
                LED1 = 1;
                LED2 = 0;
                Estado = REPOSO;
            }
            if (SW2 == 1)
            {
                localBuf[0] = '2';
                sendBuf(localBuf, 1);
                LED1 = 0;
                LED2 = 1;
                Estado = REPOSO;
            }

            if (seg)
            {
                seg = false;
                timer--;

                if (!timer)
                {
                    localBuf[0] = '0';
                    sendBuf(localBuf, 1);
                    Estado = REPOSO;
                    TMR1ON = 0;
                }
            }


            break;



        }







    }
    return 0;
}

