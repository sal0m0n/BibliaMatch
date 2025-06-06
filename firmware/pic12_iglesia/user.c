/******************************************************************************/
/* Files to Include                                                           */
/******************************************************************************/

#include <htc.h>            /* HiTech General Includes */
#include <stdint.h>         /* For uint8_t definition */
#include <stdbool.h>        /* For true/false definition */
#include "system.h"
#include "user.h"

/******************************************************************************/
/* User Functions                                                             */
/******************************************************************************/

/* <Initialize variables in user.h and insert code for user algorithms.> */

void InitApp(void)
{
    /* TODO Initialize User Ports/Peripherals/Project here */
    TRIS_BOTON_A = 1;
TRIS_BOTON_B =1;
 TRIS_BOTON_RESET =1;
TRIS_LED_AZUL =0;
 TRIS_LED_ROJO =0;
 TRIS_BUZZER =0;
    /* Setup analog functionality and port direction */

    /* Initialize peripherals */

    /* Enable interrupts */
}

