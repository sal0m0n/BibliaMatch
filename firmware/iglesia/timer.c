


#include "system.h"  

int twait_1s;
int seg;
void OpenTimer1()
{
    TMR1 = 64535;
    seg = false;
    twait_1s = 1000;

    T1CONbits.T1CKPS1 = 0;
    T1CONbits.T1CKPS0 = 0;
    T1CONbits.T1OSCEN = 0;
    T1CONbits.T1SYNC = 1;
    T1CONbits.TMR1CS = 0;
    T1CONbits.TMR1ON = 1;
    TMR1IE = 1;
}