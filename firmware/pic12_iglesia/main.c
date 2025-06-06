/******************************************************************************/
/* Files to Include                                                           */
/******************************************************************************/

#include <htc.h>           /* Global Header File */
#include <stdint.h>        /* For uint8_t definition */
#include <stdbool.h>       /* For true/false definition */

#include "system.h"        /* System funct/params, like osc/peripheral config */
#include "user.h"          /* User funct/params, such as InitApp */


//#define __delay_us(x) _delay((unsigned long)((x)*(_XTAL_FREQ/4000000.0)))
//#define __delay_ms(x) _delay((unsigned long)((x)*(_XTAL_FREQ/4000.0)))

/******************************************************************************/
/* User Global Variable Declaration                                           */
/******************************************************************************/

/* i.e. uint8_t <variable_name>; */

/******************************************************************************/
/* Main Program                                                               */

/******************************************************************************/
typedef enum {
    REPOSO,
    ESPERA,
    BBOTONA,
    BOTONA,
    BBOTONB,
    BOTONB


} estado;


estado Estado = REPOSO;

uint8_t main(void) {
    /* Configure the oscillator for the device */
    // ConfigureOscillator();

    OSCCAL = 0x3420;
    INTCONbits.GIE = 0;
   
    long contadorA = 0;
    long contadorB = 0;
    long contadorR = 0;

    /* Initialize I/O and Peripherals for application */
    InitApp();

    /* TODO <INSERT USER APPLICATION CODE HERE> */
    LED_AZUL = 1;
    LED_ROJO = 1;

    while (1) {

        switch (Estado) {
            case REPOSO:

                if (BOTON_RESET == 0) {
                    LED_AZUL = 0;
                    LED_ROJO = 0;
                    contadorA = 0;
                    contadorB = 0;
                    Estado = ESPERA;

                }
                break;
            case ESPERA:
                LED_AZUL = 0;
                LED_ROJO = 0;

                if (!BOTON_A) {
                    contadorA++;
                } else {
                    contadorA = 0;
                }
                if (!BOTON_B) {
                    contadorB++;
                } else {
                    contadorB = 0;
                }

                if ((contadorA >= 500) || (contadorB >= 500)) {
                    

                    if (contadorA > contadorB) {
                        Estado = BBOTONA;
                        GPIO = 0x5;

                    } else {
                        Estado = BBOTONB;

                      
                    }
                }
                break;

            case BBOTONA:

                GPIO = 0x5;


                if (BOTON_RESET == 0) {
                    contadorR++;
                } else {
                    contadorR = 0;
                }


                if (contadorR > 500) {
                    Estado = BOTONA;
                    GPIO = 0x4;
                    break;
                }



            case BOTONA:

                if (BOTON_RESET == 0) {
                    contadorR++;
                } else {
                    contadorR = 0;
                }

                if (contadorR > 500) {
                    Estado = ESPERA;
                    break;
                }

            case BBOTONB:
                GPIO = 0x3;
                if (BOTON_RESET == 0) {
                    contadorR++;
                } else {
                    contadorR = 0;
                }

                if (contadorR > 500) {
                    Estado = BOTONB;
                    GPIO = 0x2;
                    break;
                }


            case BOTONB:

                if (BOTON_RESET == 0) {
                    contadorR++;
                } else {
                    contadorR = 0;
                }

                if (contadorR > 500) {
                    Estado = ESPERA;
                    break;
                }
        }
    }

}

