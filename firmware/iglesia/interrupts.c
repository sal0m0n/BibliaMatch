/******************************************************************************/
/*Files to Include                                                            */
/******************************************************************************/

#include "system.h"

#define RX_BUFF_SIZE 8



/******************************************************************************/
/* Interrupt Routines                                                         */
/******************************************************************************/

char i,n;
      static char cChar;
	static UARTMsg RX1;
	static unsigned int RX1Bytes=0;
	static enum _rx1_estado
	{
		RX_ESPERA = 0,
		RX_BYTE,
		
	} rx1_estado = RX_ESPERA;

void interrupt isr(void)
{

    if (TMR1IF)
    {
        TMR1 = 64535;

        TMR1IF = 0;
        twait_1s--;
        if (twait_1s == 0)
        {
            seg = true;
            twait_1s = 1000;
        }
    }

    if(RCIF && RCIE)
    {
    while (RCIF) {

        cChar = RCREG;
        RX1.buff[RX1Bytes] = cChar;


        switch (rx1_estado)
        {
            case RX_ESPERA:

                if (cChar == 2)
                {
                    rx1_estado++;
                    RX1Bytes++;
                }
                else
                {
                    if ((cChar == 6) || (cChar == 5) || (cChar == 0x15) || (cChar == 4)) {

                        RX1Bytes++;
                        RX1.nBytes = (unsigned char) RX1Bytes;
                        RX1Bytes = 0;
                        rx1_estado = RX_ESPERA;
                        memcpy(RX1_Buffer.cValor, RX1.cValor, RX1Bytes + 1);

                        bytesRecibidos = TRUE; //Anuncio que la trama esta en RX1.cValor
                        break;
                    }
                    else
                    {
                        RX1Bytes = 0;
                        rx1_estado = RX_ESPERA;
                    }
                }

                break;

            case RX_BYTE:

                RX1Bytes++;
                if (cChar == 3)
                {
                     
                        RX1.nBytes = (unsigned char) RX1Bytes;
                        RX1Bytes = 0;
                        rx1_estado = RX_ESPERA;
                        memcpy(RX1_Buffer.cValor, RX1.cValor, RX1.nBytes + 1);

                        bytesRecibidos = TRUE; //Anuncio que la trama esta en RX1.cValor
                        break;
                }

                break;

        }

    }

    }

    if(TXIF)
    {
        int txPos = 0;

        while(TX1_Buffer.nBytes != txPos)
        {
            while(!TRMT);

            TXREG = TX1_Buffer.buff[txPos];
            txPos++;


        }
        while(!TRMT);
        TXEN = 0; /* disable the transmitter */
    }
}



