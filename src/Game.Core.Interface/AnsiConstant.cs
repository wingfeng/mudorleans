using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Core.Interface
{
    public class AnsiConst
    {
        public static readonly Dictionary<string, string> AnsiDict = new Dictionary<string, string>()
        {
            { "CSI", "\x1B[" },

            /*  Foreground Colors  */

            { "BLK", "\x1B[30m" },          /* Black    */
            { "RED", "\x1B[31m" },          /* Red      */
            { "GRN", "\x1B[32m" },          /* Green    */
            { "YEL", "\x1B[33m" },          /* Yellow   */
            { "BLU", "\x1B[34m" },          /* Blue     */
            { "MAG", "\x1B[35m" },          /* Magenta  */
            { "CYN", "\x1B[36m" },          /* Cyan     */
            { "WHT", "\x1B[37m" },          /* White    */

            /*   Hi Intensity Foreground Colors   */

            { "HIR", "\x1B[1;31m" },        /* Red      */
            { "HIG", "\x1B[1;32m" },        /* Green    */
            { "HIY", "\x1B[1;33m" },        /* Yellow   */
            { "HIB", "\x1B[1;34m" },        /* Blue     */
            { "HIM", "\x1B[1;35m" },        /* Magenta  */
            { "HIC", "\x1B[1;36m" },        /* Cyan     */
            { "HIW", "\x1B[1;37m" },        /* White    */

            /* High Intensity Background Colors  */

            { "HBRED", "\x1B[41;1m" },       /* Red      */
            { "HBGRN", "\x1B[42;1m" },       /* Green    */
            { "HBYEL", "\x1B[43;1m" },       /* Yellow   */
            { "HBBLU", "\x1B[44;1m" },       /* Blue     */
            { "HBMAG", "\x1B[45;1m" },       /* Magenta  */
            { "HBCYN", "\x1B[46;1m" },       /* Cyan     */
            { "HBWHT", "\x1B[47;1m" },       /* White    */

            /*  Background Colors  */

            { "BBLK", "\x1B[40m" },          /* Black    */
            { "BRED", "\x1B[41m" },          /* Red      */
            { "BGRN", "\x1B[42m" },          /* Green    */
            { "BYEL", "\x1B[43m" },          /* Yellow   */
            { "BBLU", "\x1B[44m" },          /* Blue     */
            { "BMAG", "\x1B[45m" },          /* Magenta  */
            { "BCYN", "\x1B[46m" },          /* Cyan     */
                                             // {"BWHT = ESC+"[47m"},          /* White    */

            { "NOR", "\x1B[2;37;0m" },      /* Puts everything back to normal */

            /*  Additional ansi = ESC codes added to ansi.h by Gothic  april 23,1993 */
            /* Note, these are = ESC codes for VT100 terminals, and emmulators */
            /*       and they may not all work within the mud               */

            { "BOLD", "\x1B[1m" },          /* Turn on bold mode */
            { "CLR", "\x1B[2J" },          /* Clear the screen  */
            { "HOME", "\x1B[H" },        /* Send cursor to home position */
                                         //   {"REF", CLR + HOME;        /* Clear screen and home cursor */
            { "BIGTOP", "\x1B#3" },      /* Dbl height characters, top half */
            { "BIGBOT", "\x1B#4" },      /* Dbl height characters, bottem half */
            { "SAVEC", "\x1B[s" },       /* Save cursor position */
            { "REST", "\x1B[u" },       /* Restore cursor to saved position */
                                        //{"REVINDEX = ESC+"m"},        /* Scroll screen in opposite direction */
            { "SINGW", "\x1B#5" },      /* Normal, single-width characters */
            { "DBL", "\x1B#6" },     /* Creates double-width characters */
            { "FRTOP", "\x1B[2;25r" },    /* Freeze top line */
            { "FRBOT", "\x1B[1;24r" },    /* Freeze bottom line */
            { "UNFR", "\x1B[r" },    /* Unfreeze top and bottom lines */
            { "BLINK", "\x1B[5m" },       /* Initialize blink mode */
            { "_U_", "\x1B[4m" },             /* Initialize underscore mode */
            { "REV", "\x1B[7m" },           /* Turns reverse video mode on */
            { "HIREV", "\x1B[1,7m" }      /* Hi intensity reverse video  */
        };

        public const string ESC = "\x1B";
        public const string CSI = ESC + "[";

        /*  Foreground Colors  */
        /// <summary>
        /// Black
        /// </summary>
        public const string BLK = ESC + "[30m";          /* Black    */
        /// <summary>
        /// Red
        /// </summary>
        public const string RED = ESC + "[31m";          /* Red      */
        /// <summary>
        /// Green
        /// </summary>
        public const string GRN = ESC + "[32m";          /* Green    */
        /// <summary>
        /// Yellow
        /// </summary>
        public const string YEL = ESC + "[33m";         /* Yellow   */
        /// <summary>
        /// Blue
        /// </summary>
        public const string BLU = ESC + "[34m";          /* Blue     */
        /// <summary>
        /// Magenta
        /// </summary>
        public const string MAG = ESC + "[35m";          /* Magenta  */
        /// <summary>
        /// Cyan
        /// </summary>
        public const string CYN = ESC + "[36m";          /* Cyan     */
        /// <summary>
        /// White
        /// </summary>
        public const string WHT = ESC + "[37m";          /* White    */

        /*   Hi Intensity Foreground Colors   */
        /// <summary>
        /// High Red
        /// </summary>
        public const string HIR = ESC + "[1;31m";        /* Red      */
        /// <summary>
        /// High Green
        /// </summary>
        public const string HIG = ESC + "[1;32m";        /* Green    */
        /// <summary>
        /// High Yellow
        /// </summary>
        public const string HIY = ESC + "[1;33m";        /* Yellow   */
        /// <summary>
        /// High Blue
        /// </summary>
        public const string HIB = ESC + "[1;34m";        /* Blue     */
        /// <summary>
        /// Hi Magenta
        /// </summary>
        public const string HIM = ESC + "[1;35m";        /* Magenta  */
        /// <summary>
        /// High Cyan
        /// </summary>
        public const string HIC = ESC + "[1;36m";        /* Cyan     */
        /// <summary>
        /// White
        /// </summary>
        public const string HIW = ESC + "[1;37m";        /* White    */

        /* High Intensity Background Colors  */

        public const string HBRED = ESC + "[41;1m";       /* Red      */
        public const string HBGRN = ESC + "[42;1m";       /* Green    */
        public const string HBYEL = ESC + "[43;1m";       /* Yellow   */
        public const string HBBLU = ESC + "[44;1m";       /* Blue     */
        public const string HBMAG = ESC + "[45;1m";       /* Magenta  */
        public const string HBCYN = ESC + "[46;1m";       /* Cyan     */
        public const string HBWHT = ESC + "[47;1m";       /* White    */

        /*  Background Colors  */

        public const string BBLK = ESC + "[40m";          /* Black    */
        public const string BRED = ESC + "[41m";          /* Red      */
        public const string BGRN = ESC + "[42m";          /* Green    */
        public const string BYEL = ESC + "[43m";          /* Yellow   */
        public const string BBLU = ESC + "[44m";          /* Blue     */
        public const string BMAG = ESC + "[45m";          /* Magenta  */
        public const string BCYN = ESC + "[46m";          /* Cyan     */
        public const string BWHT = ESC + "[47m";          /* White    */

        public const string NOR = ESC + "[2;37;0m";      /* Puts everything back to normal */

        /*  Additional ansi = ESC codes added to ansi.h by Gothic  april 23,1993 */
        /* Note, these are = ESC codes for VT100 terminals, and emmulators */
        /*       and they may not all work within the mud               */

        public const string BOLD = ESC + "[1m";          /* Turn on bold mode */
        public const string CLR = ESC + "[2J";          /* Clear the screen  */
        public const string HOME = ESC + "[H";          /* Send cursor to home position */
        public const string REF = CLR + HOME;          /* Clear screen and home cursor */
        public const string BIGTOP = ESC + "#3";        /* Dbl height characters, top half */
        public const string BIGBOT = ESC + "#4";       /* Dbl height characters, bottem half */
        public const string SAVEC = ESC + "[s";          /* Save cursor position */
        public const string REST = ESC + "[u";        /* Restore cursor to saved position */
        public const string REVINDEX = ESC + "m";        /* Scroll screen in opposite direction */
        public const string SINGW = ESC + "#5";      /* Normal, single-width characters */
        public const string DBL = ESC + "#6";       /* Creates double-width characters */
        public const string FRTOP = ESC + "[2;25r";   /* Freeze top line */
        public const string FRBOT = ESC + "[1;24r";   /* Freeze bottom line */
        public const string UNFR = ESC + "[r";     /* Unfreeze top and bottom lines */
        public const string BLINK = ESC + "[5m";         /* Initialize blink mode */
        public const string U = ESC + "[4m";             /* Initialize underscore mode */
        public const string REV = ESC + "[7m";           /* Turns reverse video mode on */
        public const string HIREV = ESC + "[1,7m";       /* Hi intensity reverse video  */
    }
}
