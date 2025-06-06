/* 
 * File:   timer.h
 * Author: Salomon
 *
 * Created on 6 de enero de 2014, 10:18 PM
 */
#include <htc.h>            /* HiTech General Includes */
#include <stdint.h>         /* For uint8_t definition */
#include <stdbool.h>        /* For true/false definition */




#ifndef TIMER_H
#define	TIMER_H

#ifdef	__cplusplus
extern "C"
{
#endif

   extern int twait_1s;
   extern int seg;

   extern void OpenTimer1();
#ifdef	__cplusplus
}
#endif

#endif	/* TIMER_H */

