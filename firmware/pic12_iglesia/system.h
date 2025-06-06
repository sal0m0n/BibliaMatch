/******************************************************************************/
/* System Level #define Macros                                                */
/******************************************************************************/
#define BOTON_A GPIObits.GP5
#define BOTON_B GPIObits.GP4
#define BOTON_RESET GPIObits.GP3
#define LED_AZUL GPIObits.GP2
#define LED_ROJO GPIObits.GP1
#define BUZZER GPIObits.GP0




#define TRIS_BOTON_A TRISIObits.TRISIO5
#define TRIS_BOTON_B TRISIObits.TRISIO4
#define TRIS_BOTON_RESET TRISIObits.TRISIO3
#define TRIS_LED_AZUL TRISIObits.TRISIO2
#define TRIS_LED_ROJO TRISIObits.TRISIO1
#define TRIS_BUZZER TRISIObits.TRISIO0

/* TODO Define system operating frequency */

/* Microcontroller MIPs (FCY) */
//#define SYS_FREQ        500000L
//#define FCY             SYS_FREQ/4

/******************************************************************************/
/* System Function Prototypes                                                 */
/******************************************************************************/

/* Custom oscillator configuration funtions, reset source evaluation
functions, and other non-peripheral microcontroller initialization functions
go here. */

void ConfigureOscillator(void); /* Handles clock switching/osc initialization */
