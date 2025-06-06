/******************************************************************************/
/* User Level #define Macros                                                  */
/******************************************************************************/




/* TODO Application specific user parameters used in user.c may go here */

/******************************************************************************/
/* User Function Prototypes                                                   */
/******************************************************************************/

/* TODO User level functions prototypes (i.e. InitApp) go here */

void InitApp(void);         /* I/O and Peripheral Initialization */
extern volatile char bytesRecibidos;
extern volatile char rx_data[8];


typedef enum {
    REPOSO,
    PULSADOR

} estado;

estado Estado = REPOSO;

typedef struct {

    union {

        struct {
            unsigned char nBytes;
            unsigned char buff[20];
        };
        unsigned char cValor[21];
    };
} UARTMsg;

        #define TRUE 1
#define FALSE 0

       extern UARTMsg RX1_Buffer;
       extern UARTMsg TX1_Buffer;

#define SW1 PORTCbits.RC2
#define SW2 PORTCbits.RC3
#define LED1 PORTBbits.RB0
#define LED2 PORTBbits.RB1

