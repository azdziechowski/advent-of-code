using System.Text;

namespace AdventOfCode._2024;

[TestFixture]
public class Day7
{
    private const string TestInput =
        """
        190: 10 19
        3267: 81 40 27
        83: 17 5
        156: 15 6
        7290: 6 8 6 15
        161011: 16 10 13
        192: 17 8 14
        21037: 9 7 18 13
        292: 11 6 16 20
        """;

    private const string Input =
    """
    644197722674: 5 9 46 99 1 5 9 2 22 6 74
    3424919: 67 51 7 561 358
    7160145: 9 9 7 4 8 3 91 2 3 3 5 731
    1133404163: 231 3 49 2 32 128 36
    198444: 9 77 90 347 308 46 3
    258135: 7 61 68 6 249 6
    10677865: 864 7 4 1 9 4 7 7 1 5 367
    1134: 54 7 3
    28760910: 1 6 627 9 752 831
    6740: 82 236 356 10
    983873830: 977 6 267 606 830
    101904: 5 71 29 2 264
    8536122: 5 3 7 388 120
    818217: 8 27 21 484 92 5 214
    9221: 219 23 270 18 5
    216699547: 2 24 46 9 1 55 6 61 9 88
    19040: 434 4 5 2 41 713 28 54
    113740483608: 52 951 38 417 23 17
    1837300: 627 46 5 1 91 6 6 4
    21564: 6 143 330 9 5 9
    100992468: 4 4 2 9 7 69 3 24 92 8 6 8
    522672: 5 226 7 5
    72660535: 181 857 70 5 2 4 1 11
    1553455: 57 842 4 650 374 79
    177565304: 177 5 6 530 7
    123464883: 65 67 315 7 2 45
    162378: 47 799 75 702 74 3
    75882558: 4 4 9 3 8 7 5 29 5 4 57 5
    15486: 5 771 6 1 2 2 8 8 8 8 2 4
    195018949: 237 9 76 61 19 95 4 9 9
    120067914: 12 7 1 282 9 17 7 2 7 79
    10625355: 6 16 906 3 533
    714034: 2 3 60 7 7 90 325 9
    147283595568: 3 311 33 3 57 822 8 93
    2316922: 8 26 41 831 2 94
    182954295: 438 22 56 5 993 4
    17143497694679: 73 169 33 1 4 71 6 79
    758512003463: 3 2 790 700 4 2 2 34 63
    4146569285: 280 8 9 5 6 7 68 4 9 1 2 5
    31770235539495: 589 8 9 1 1 95 3 63 492
    2140548: 7 6 1 4 3 4 8 929 1 3 8 12
    12113461: 291 3 50 772 17 5 2 2
    9197820380208: 1 58 583 110 58 207
    1539915: 88 340 19 5 689
    198635345304: 19 711 980 6 44 341
    43172: 426 8 4 318 1 1 439 3 5
    53202: 5 3 7 1 4 79 62 6 6
    999074: 1 4 221 5 9 71
    107010: 2 1 29 410 3
    1207: 8 600 5 9 567 17 1
    963: 56 902 7
    3661: 87 42 4 3
    55680: 8 7 2 58 8 4
    1443280: 1 33 16 68 39 592
    11791444132: 954 3 412 412 9
    40408: 8 8 513 70 19
    895: 45 9 784 52 8
    3630590257: 5 787 5 98 113 94 57
    1219939: 9 5 183 9 3
    7243377: 1 231 8 2 1 36 6 5 795 3
    10281688290: 728 359 69 874 8 45
    52129140: 78 1 7 407 547 5 2 4 5
    844925: 778 18 78 6 8
    1517768001: 56 213 629 27 17
    1586: 26 1 18 35 9
    897822305: 10 89 7 8 222 55 52
    307677984: 38 946 58 79 2
    11629377: 7 10 83 82 37 548 6 79
    5706366: 203 30 937 6 1 26
    545930: 1 8 696 5 770
    21436: 57 94 4 4 1
    601219587: 2 5 1 2 1 1 4 1 1 912 327
    1210568: 5 3 9 86 1 1 98 2 8 97 6 8
    163672: 311 939 4 1 130 522
    816: 3 9 7 9 5 25 84 186 56
    413330: 71 9 181 504 50
    275151204: 5 8 9 8 4 3 433 1 5 6 7 3
    5565: 47 19 8 7 1 276
    5528836: 1 552 789 9 936
    30771: 42 81 5 12 9
    113510: 99 58 723
    2552925934889: 802 8 795 54 8 372 4 6
    13201: 45 124 77 31 159
    720468: 17 6 92 4 7
    22380384159: 7 8 166 29 159 1 3 2 8 2
    45770: 4 41 765 2 3
    32957: 4 28 886 71
    5110126: 6 173 214 66 8
    1762745: 982 227 3 3 27 3 6 5
    130796643: 131 32 1 5 5 624
    78364255: 8 9 694 57 7 253
    844276: 8 42 224 792 1
    362023: 9 25 594 5 5 40 87 103
    1291399844: 5 6 1 9 39 1 73 9 6 44
    228417920: 25 37 71 9 26 794 8 4
    40050828: 3 27 763 6 9 9 5 1 9 12
    116627652: 7 4 7 1 446 8 4 5 2 4 75 6
    2516095717: 7 385 8 43 59 8 5 46
    655270872: 9 2 8 159 89 2 9 3 89 95
    35298709: 6 41 170 3 2 422 97
    558606: 4 6 5 74 6 53 7 7 100 1 5
    96911: 5 9 75 6 9 665 2 7 9 2 7 8
    429735: 7 72 58 6 9
    9402: 3 453 9 86 920 1 7 88 6
    2948456: 69 251 9 68 456
    254061: 603 70 2 6 789
    27948: 485 575 322 262 17
    90873: 58 49 8 27 31 31 725
    6444009: 5 6 195 7 6 33 13
    17255343: 78 867 42 3 85
    144630242: 490 2 39 11 7 4 39 86 1
    444869: 4 7 8 878 5 479
    253242155: 42 203 6 7 234 57
    1823338: 2 414 9 487 4 6
    25234118: 91 683 58 7 1
    642484013: 917 822 4 6 1 7 9 1 2
    10018629: 99 944 235 99 628
    52518012: 663 80 8 5 99
    52968775714: 217 3 8 2 3 2 9 6 9 9 94 6
    7014: 1 666 9 933 8 70
    1210591: 39 8 40 97 31
    61925382: 366 648 1 1 9 837 29
    1392623100: 92 3 6 6 8 18 8 815 990
    146952: 66 53 92 6 677 43
    16148106: 41 31 9 5 4 39
    972134: 4 36 905 3 28 9 75 54 3
    1699: 9 7 94 2
    38915712: 66 83 4 3 296 2 1
    24871732: 71 178 3 656 148
    1016303031: 229 634 7 499 532
    553520: 7 3 7 22 69
    588423590: 2 1 9 143 8 3 6 923 1 3 4
    8360806312: 1 3 9 850 24 7 857 5 7 5
    462718: 4 6 26 93 26
    21935424: 280 60 96 2 4 2 84
    885836: 8 850 4 5 2 27 704 58 9
    797703006: 1 3 1 8 9 4 9 495 3 7 60 6
    7714822: 2 4 757 959 3 25
    233319196: 881 27 45 10 4 979
    451620568437: 170 6 57 4 9 5 56 8 439
    2836062720: 7 88 111 9 6 6 2 4 3 8 3 2
    81217110: 827 98 9 501 2
    21081: 6 3 41 6 3 1 6 324 8 5 8
    861: 7 7 2 44 801
    88: 4 4 73 5 2
    1570446660: 9 198 6 7 4 39 9 9 1 6 5 1
    14270753: 5 934 7 5 6 6 2 3 2 6 99
    56568223: 845 8 523 34 16 1
    650438051: 8 3 17 8 3 7 4 743 3 7 2 4
    3543: 7 57 24 125 61 80 1
    41612: 26 7 70 18 24 8
    198303162: 82 81 8 142 7 3 5 6 6 6
    4195337168: 8 3 17 948 5 3 3 3 4 7 68
    2593123: 40 76 853
    5764808331: 1 18 3 4 9 7 573 4 7 9 6
    109985400: 7 6 2 848 1 97 4 7 3 35
    386253: 81 7 5 5 603 551
    70791407: 2 2 5 2 22 96 2 8 3 52 2 2
    10455350486: 758 2 33 965 8 54 86
    412382916057: 1 9 39 6 45 627 184 58
    205995206: 6 112 4 7 77 933 9
    138335075997: 1 6 3 7 9 3 2 550 990 8
    360062993: 3 4 85 4 8 896 4 966 8 9
    8288395: 89 45 4 273 1 22 1 90
    75413380: 63 748 9 3 2 2 1 4 21 4
    2737489: 5 9 53 9 48 6
    5050164: 1 7 297 55 4 613
    372470: 1 4 15 230 9 3 85
    43071377128: 4 307 1 3 7 25 9 7 365 5
    1388: 6 99 32 59 554 149
    727612: 4 478 380 6 1 838 228
    6994892: 37 50 5 378 1
    5686664574: 5 68 62 3 6 9 3 2 9 569 7
    1143128724150: 92 287 6 8 5 525 859 2
    41306: 910 82 19 76 38
    1986: 84 65 9 540 74 31
    10921388868: 61 74 113 61 66 351
    1617983: 38 91 67 459 8
    7273: 79 82 764 2 23 6
    1681: 8 1 788 379 506
    1733837: 3 9 443 61 37
    426492: 78 9 57 1 2 315 9 22 1 2
    21672129332: 86 252 1 293 31
    131979: 936 47 3 1 2
    21284859377: 3 7 161 854 5 7 75 625
    194833581: 5 954 6 88 5 5 9 198 8
    1358996: 1 71 567 5 8 66 5 4 960
    213170975: 88 821 24 24
    1753764808: 41 7 4 6 8 7 4 1 5 7 5 810
    15881128: 28 544 24 2 6 9 1 4 578
    1911: 46 809 68 38 7 938 1 5
    4907534410: 1 6 1 9 5 6 409 2 9 7 43 6
    8189947079: 5 4 8 8 9 3 808 1 7 77 6 5
    507174405: 3 675 561 82 784 3 2
    470600798: 1 9 6 5 5 359 5 3 69 90 7
    77885: 784 33 27 55 3 22
    26494743: 95 90 62 549 5
    886638: 54 4 8 8 8 5 4 2 1 5 4 1
    81696: 822 2 2 56 48
    199643920: 509 6 3 20 67 2 952
    24054306505: 67 534 955 59 704 9
    36855: 5 9 39 21
    70289942: 370 7 91 1 91 4 1 6 6 7 2
    72733596: 12 9 619 335 99
    6222893: 620 2 260 9 20 3
    19516095: 30 3 6 7 7 59 42 8 94 2
    891796: 84 807 794
    49196: 182 1 3 6 9
    2717456088: 4 3 53 5 647 9 2 89 59 6
    4767272: 88 1 878 9 1 61
    881931: 74 7 68 5 301
    358318816: 9 95 33 36 15
    15261700: 4 75 137 4 48 8 46 4
    7480: 430 408 4 9 249 2 260
    55931515717: 7 18 819 9 83 5 5 7 3 1 7
    188671: 762 2 6 7 35 21
    120025246: 56 893 6 8 48 3 948 4
    123188: 2 74 58 598
    36478821: 725 4 57 5 2 8 8 1 3 1 27
    89822860: 6 9 20 5 3 9 9 9 5 5 1 13
    3333672: 9 76 9 6 8 9 1 1 8 8 1 9
    334667916: 2 9 681 219 204
    37897612: 4 8 6 3 9 6 7 8 74 7 31 1
    3585801: 78 9 5 2 406 6 8 2 7
    225846: 4 93 994 207 9
    97481836858: 974 736 82 3 68 59
    8798000: 74 494 262 106 2 50 1
    987: 9 606 19 349 4
    35956582523: 420 855 465 82 526
    19426789: 66 1 545 4 6 6 9 1 775
    455625: 4 5 1 4 89 15 55 2 1 2 5 9
    1140143: 705 49 33 132 26
    30028: 50 6 22 1 5
    100704802450: 5 91 96 1 2 6 4 3 577 7
    11364984: 163 163 58 1 58 6
    1337700: 3 66 5 86 9 510 5
    2110176: 58 4 2 2 237 1 2 4 431 8
    28139: 540 97 44 8 1 33 1 68
    2747718494: 392 53 7 77 7 7 8 15
    2660397: 2 8 49 613 1 2 9 8 5 5 1 6
    54157: 902 200 7 7 159
    35995590749608: 891 8 8 8 9 7 6 87 4 5 8 8
    9459: 3 3 3 15 9
    802075: 751 89 12 6 1
    2187785: 937 6 334 708 7 1 3 5
    83880596467: 931 1 9 5 33 134 3 6 1 3
    3960: 944 4 89 95
    3201184: 531 855 5 14 461
    44968268: 58 7 89 292 266
    297099078: 79 5 885 45 35 1
    1888: 83 96 9 10 8
    4185068: 616 8 122 85 66 8
    461760: 94 296 4 74 4
    4655: 19 6 19 5 7
    4668693144946: 59 38 4 91 40 453 9 6 9
    69615016: 974 1 1 714 14
    114617661: 992 917 126
    971801: 7 5 3 3 3 51 47 965 5 4
    795940491: 355 3 3 1 2 28 3 2 5 8 9
    13321847987: 6 9 3 84 81 8 7 8 72 7 87
    18738947047: 1 4 92 5 6 2 1 19 3 52 2 7
    25010: 28 6 5 637 77 90
    1088100: 5 98 899 1 14 775
    32567: 9 88 2 20 887
    1821252960: 7 871 6 430 804
    137875: 684 6 46 4 5 35
    56572801202: 2 4 15 421 458 36 2
    87958367: 6 808 6 62 23 997 36
    13422: 497 27 1 3
    11257638: 3 784 6 40 6 1 276 119
    453647563: 2 935 6 2 8 79 6 1 3 3 6
    181924028: 91 7 3 5 25 6 2 9 3 7 44
    48196638: 89 7 80 10 43 966
    379859368: 219 8 3 9 54 6 4 9 1 6 6 4
    218625: 364 28 6 3 53
    545: 14 6 2 333 66
    12800868: 48 6 342 33 77
    14669424: 8 2 1 8 2 7 3 2 378 7 4 42
    124997919: 74 5 9 2 49 89 6 2 987 6
    20750680: 3 2 91 9 6 4 4 5 6 3 955 2
    66450: 949 3 7
    13632: 15 91 4 2 32
    54210949: 9 8 3 2 85 8 8 54 1 9 7 7
    18118147545: 731 4 3 66 12 41 3 5 46
    5480584325: 782 9 406 7 48 4 8 68
    21390324251: 21 18 602 641 94
    1986513: 662 1 67 3 9
    19984807398: 757 4 660 73 99
    25152285068: 2 4 3 776 5 49 1 1 7 6 3 9
    26473: 3 8 2 47 3
    6177: 1 8 30 8 7 51 4 52 4 1
    769278135: 7 687 3 9 45 4 4 128 2 6
    923145787440: 782 3 2 538 77 590 8
    1631: 1 6 4 51 3 19 1 1 3 8 403
    40729: 93 2 2 796 2 8 2 3 236
    2654: 4 40 2 30 3 8
    51429247: 2 2 853 153 6 2 24 7 33
    132157: 1 241 53 8 297 2
    1449808: 3 39 6 875 52 890
    4332: 5 34 513 4 5 47 7 12 64
    21620085167613: 1 3 90 251 8 51 67 616
    22498560: 37 5 31 80 8 27
    13943884: 6 28 5 7 5 177 1 38 8 2 2
    35728046482: 2 49 852 2 14 94 4 8 3
    45088: 20 83 27 191 77
    561675243: 4 4 5 7 2 8 2 3 1 629 63 3
    46480040: 50 798 3 2 332 5 2 29 2
    606184069431: 1 86 59 7 7 242 7 22 4 6
    2425653532803: 2 320 658 405 30 3 64
    424844740: 643 11 7 677 1 67 7 6
    398668004514: 52 15 43 7 78 98 23 4
    2137402: 533 88 47 4 3
    6048720: 19 97 426 93 120
    5351978974: 94 295 461 193 1
    8222557572: 8 33 17 1 501 12 981
    323197: 1 619 5 4 73 19 5 2
    1243: 3 274 421
    4105039: 5 3 3 386 50 40
    363325010: 9 7 99 588 52 949 58
    111187760: 4 75 482 5 2 292
    11212420: 2 5 16 11 686 732
    2830619: 763 75 2 639 3 191 1
    2043461: 3 64 662 8 4 3 7
    18472960510: 67 9 6 91 45 3 231 68
    1882444276631: 9 64 5 9 90 4 4 276 631
    2130224: 91 660 2 4 3 938 26
    325749: 7 989 47 368
    45497: 3 4 7 5 6 1 5 933 6 6 5 60
    38655649296: 2 44 642 97 2 5 8 9 968
    46001759909: 5 351 55 5 274 5 6 215
    78513754: 4 128 4 210 7 86 19
    1471036396: 2 87 92 79 8 7 398
    4803: 7 5 2 9 79 42 2 2 515
    156208548: 5 8 31 97 37 6 4 9 88 3
    1055599537: 65 974 971 2 8 1
    5025498431: 502 549 843 1 1
    102599297: 43 71 95 33 1 89 91 4
    83434050: 9 315 5 654 9
    9566: 3 44 96 269 2 2
    276596: 10 60 26 99 6
    735428921940: 90 50 319 956 85
    1197162258: 2 98 8 8 6 89 245 25 2 9
    2315466299: 54 992 775 79 28
    13330803666: 5 576 823 360 36 3 3 8
    15657: 25 4 98 37 908 8 3 4
    262990: 4 8 3 26 289
    79663: 56 9 28 5 3
    1076093: 80 160 1 84 28 1 2 779
    503308: 53 419 966 35 8
    1052110: 923 128 390 720 1
    3281758304: 5 1 3 258 79 156 5 64 5
    33098493: 64 852 47 17 3 4
    5141121: 722 30 4 501 8 8 8 3
    472447488: 21 3 93 4 9 702 618 84
    76752518: 4 3 1 848 6 3 9 30 8 13 9
    36746210: 2 9 3 1 2 8 59 4 86 148 9
    57519732: 390 5 5 5 866 164 5 7
    337213: 98 6 539 146 6 1
    38484: 27 249 70 3 9 19 3 9 4
    140760: 95 4 821 51 3
    37597: 625 60 2 96
    1834717746: 3 61 4 717 746
    6159947: 7 510 28 99 235 992 7
    37702450: 700 43 7 87 317 9 5 1
    77382285: 1 773 82 1 287
    50794203: 8 419 4 11 3 8 517 5 36
    1926604832: 75 25 8 256 30 2
    84094: 1 7 3 4 1 2 298 4 2 3 8 26
    1585371522800: 5 53 3 18 42 87 8 8 850
    10736695: 201 8 7 760 935
    102989717: 258 677 91 398 56
    4989012: 56 30 1 886 832
    126070960: 9 3 2 31 4 65 875 8 4 80
    12281236052: 2 6 9 19 54 6 1 69 95
    348194845864: 6 215 6 279 967 65
    34950330354: 1 1 89 357 303 12 39
    15988: 5 2 4 3 884 8 785 1 1 2
    33325110: 9 7 338 313 5
    93162624: 7 8 5 2 7 9 5 8 6 8 8 912
    234504147: 830 663 910 2 47 3 2
    27489: 1 74 2 389 96 49
    11389842: 2 619 1 1 115 3 2 40 3
    3432004223: 901 9 6 96 905 44 4 4 6
    1973: 95 398 4 1
    21238: 2 5 426 6 5 8 2 54 356 2
    67284504: 670 754 71 2 9 4 6 5 5
    365693742: 63 8 9 8 2 1 3 5 1 99 3 6
    2825: 66 3 194 3 5 52 196 1
    131124: 36 6 204 312 76 5
    1565071058656: 687 70 411 7 8 8 707 2
    21424808448: 617 5 3 3 7 9 9 4 6 976 6
    46699: 56 136 3 81 36 1 4
    71483342503: 7 1 219 15 6 4 1 8 5 34 2
    274006: 301 3 4 90 47
    12744: 4 805 784 8
    2562: 1 5 505 37
    441997: 95 91 563 48 13
    2065280098: 16 99 569 250 81 3 3 5
    8238200993478: 1 2 98 8 8 584 9 7 2 7 7 9
    9968200682: 996 8 19 3 6 5 6 5 6 5 8 8
    21757761: 60 438 2 9 4 5 3 78
    7380: 72 1 79
    142146046: 62 5 5 7 7 7 2 2 3 602
    288475489801: 26 7 4 427 7 400 9 3
    1302: 3 7 62
    2920860: 26 4 601 1 162
    10662680: 3 1 80 952 8 7 5
    1944870: 8 1 15 7 4 1 5 7 1 338 3 6
    21107774: 5 97 386 8 536 94
    5958425: 7 744 9 5 7 1 56 4 2 4 2 1
    1451281979: 1 9 656 88 1 419 5 6 29
    487083093562: 3 6 4 4 5 7 4 23 55 5 952
    7048222: 84 3 452 8 222
    23400979: 812 4 4 9 2 8 6 8 326 1 9
    97944: 9 8 54 2 7 8 17 8 8 88
    18499581: 9 4 1 32 2 8 32
    184237: 8 6 4 5 4 4 1 1 836 4 53 9
    6859352895: 836 2 9 99 4 8 8 8 3 41 5
    531090: 7 542 13 9 105
    4744582: 176 6 478 6 26
    269093732: 1 4 268 9 2 1 722 662
    120462839: 6 856 7 7 5 5 134 186
    14976272: 23 4 16 4 22 4 49
    1875735: 14 253 848 81 7 1 230
    22760: 3 19 171 8 5 6 4 5 86 6 9
    11193: 9 3 843 6 13
    248540: 9 32 27 22 2 3 2 5 990 5
    24387814947: 382 5 2 7 1 698 255 5
    2381794505735: 8 1 416 235 283 73 5
    152131950: 35 4 8 92 53 40 711
    22865878: 94 20 2 65 877
    189075841: 2 99 1 3 5 8 2 7 2 31 6 40
    81091: 937 66 80 5 3 842
    557721414: 92 640 1 74 1 2 7 64 4 2
    113171295757: 9 3 9 3 9 27 4 1 3 957 5 6
    43780442: 3 4 65 40 561
    1362932167: 170 1 3 57 1 6 78 8 4 8 5
    193046119: 3 93 355 2 6 59 48 6 1
    6596126878: 8 10 9 349 205 63 78
    145305: 9 682 5 15 1
    172032954: 19 1 8 652 1 2 57 72 54
    2836938: 76 1 70 402 3 8 47 6
    787578: 93 89 978 85 868 35
    208608701: 5 729 26 6 46 2 43 7
    4667: 23 95 39 63 2
    136093592: 848 987 815 1 9 91
    124671: 27 2 5 7 9 64
    328235241523: 694 23 2 74 91 514 7 4
    294810390: 9 8 6 7 9 2 9 8 298 8 26 7
    24048413505: 674 4 892 9 34 9 1 8
    53013993575: 78 3 401 729 167 775
    8984: 937 81 99 6 8
    21995734134: 32 64 895 4 71 3 78 3
    264862905: 87 516 5 118 7 3 5
    255776495: 9 257 2 307 9 47 7 2
    1908918: 7 81 34 4 99
    973680: 32 72 3 39 3 10 8
    410673999: 76 8 85 88 550
    166255766537: 9 8 7 2 1 6 8 673 2 6 1 9
    128304: 81 6 4 66
    27879153: 640 74 1 2 3 7 44 65 5
    44232: 7 5 191 2 194
    18187369: 42 296 5 1 86
    47785: 9 747 36 7 472
    301356: 27 1 9 1 80 1 4 99
    380883: 94 6 6 4 85
    8858507: 8 1 858 495 7 2
    10086: 8 986 5 9 6
    5472230949: 73 1 9 7 7 8 24 9 7 9 6 7
    242207: 202 109 11 9
    6507402: 3 357 98 62 6
    257308250: 82 63 74 982 485 50
    46347841: 3 4 44 2 38 6 1 33 4
    4063680: 196 70 2 3 2 2 4 9 415
    902880: 316 6 934 6 7 199 3
    97144: 501 838 8 9 5 2 8 2 722
    66767570413: 7 6 5 69 5 56 7 10 6 4 1 6
    1121988: 16 73 240 4 708
    2048596: 560 8 8 64 3 9 2 2 5 41 2
    25139200: 51 6 23 982 320
    136552: 57 3 6 9 367 993 93 43
    890: 84 1 6 1 382
    667845017: 8 73 5 75 3 340 2 3 17
    210544: 36 299 9 6 51 4 4 2
    307152: 575 57 27 2 9
    174196113: 28 7 801 640 1 21 13
    488160: 55 6 71 971 7 20
    19025410: 5 1 7 734 6 4 5 18 130
    2556797688: 5 6 958 6 4 7 6 9 7 22 1
    401: 276 1 95 27 5
    2606: 21 79 901 28 18
    1008: 8 2 5 2 8
    30280923107283: 7 3 7 8 3 87 5 57 6 95 9 8
    1112133: 2 19 88 6 8 8 134
    1156070: 58 619 767 36 73 8
    8595258: 58 18 686 4 350 3
    27176091: 8 60 316 9 4
    1396445753: 9 932 185 2 76 502 1 2
    3152523: 386 58 71 45 78
    46561: 75 3 1 4 3 1 96 905 2 8 7
    74455179: 7 2 3 9 1 4 5 3 753 657
    378892728: 3 78 892 7 28
    30660568493: 51 3 4 915 74 62 8
    174848: 74 604 16 80 16
    3369813: 26 37 78 967 573
    6425: 227 4 7 70
    74081532: 681 681 34 57 931
    269511317: 3 88 83 608 6 66 62 5 5
    10740: 7 88 30 54 30 2
    32487007: 49 390 50 34 7
    31801728: 555 57 166 73 1
    1251384: 102 73 4 6 1 64 7
    6167863296: 130 2 3 484 5 6 5 6 666
    1750505577603: 33 68 237 920 780
    692005: 80 865 5
    404677: 24 8 13 162 325
    445704481829: 6 913 334 5 6 9 406 9 2
    51026: 160 15 60 7 1 31
    4395396697: 7 1 865 1 4 7 7 18 9 3 4
    3597445173: 73 8 560 47 11 3
    238958: 4 68 4 3 335 1 77 6 1 9 8
    4845972440: 3 7 741 1 505 35 18
    1047: 451 3 94 473 26
    3366: 8 437 1 676 3
    2310950: 9 51 3 1 6 228 272 38
    1204001: 43 28 4 5 50
    1770832476: 4 3 9 885 1 88 8 9 3 574
    89: 7 2 76
    3962488418: 2 27 5 381 9 16 349 4
    49284: 5 240 5 2 288 2 9
    78660218288: 65 550 18 5 6 5 7 4 8
    37209: 3 6 179 4 62 6 961
    138: 2 7 7 69 6
    16171846: 485 521 64 3
    28710: 9 78 3 22 5
    6511835: 7 6 2 5 39 18 7 8 6 152 2
    1530367213: 1 6 6 5 183 1 5 6 2 8 8 6
    14945092032747: 28 5 21 168 524 73 1 6
    99320779809: 408 93 620 1 33 6 10
    6606342065: 6 738 4 4 6 817 3
    16207982550: 193 715 3 2 3 6 675 29
    580720115: 82 6 522 952 115
    101346: 87 8 7 6 1 6 353 2 8 7 2 7
    43782921: 8 935 29 7 7
    350811824: 907 58 36 79 46
    51161294: 15 297 348 33 59 15 1
    56283832271: 556 6 83 832 271
    11999796: 5 9 1 4 3 9 1 25 2 4 9 7
    151528089: 8 947 2 7 60 9 357 123
    10552401805: 5 711 3 7 4 5 74 904 2 1
    6975525183444: 75 8 2 4 3 694 9 628 23
    221946: 212 29 389 576 3
    32164662625: 47 3 68 608 7 539 18 7
    193348: 9 54 6 973 51
    147818390: 803 752 98 3 95 3
    13461188087: 11 6 372 4 3 2 676 1 85
    1595250: 4 4 2 4 5 57 583 5 5 90
    163120921251: 8 33 4 29 1 599 534 81
    627115008: 4 6 3 70 9 4 6 36 2 8 24 8
    262845099: 11 25 59 162 99
    158070817: 576 214 35 2 816
    27810: 67 826 7 27 30
    108334487: 5 299 3 21 345
    377712: 6 88 7 9 46 77 3 122
    4403487698: 1 123 32 7 6 6 7 7 6 8 9 9
    18000: 243 7 1 9 8
    1133048448: 9 5 64 7 4 7 4 82 46 7 2 9
    22753166439: 3 2 7 9 6 2 8 78 3 9 462 2
    401539425944: 7 7 4 9 5 721 6 3 5 3 944
    151632037: 6 8 975 8 405 1 18 7 12
    2061467: 9 8 4 1 1 5 303 7 458 9
    469247481: 184 9 6 83 569 9
    804: 48 2 5 79 475
    25426: 9 556 1 9 5
    530948520: 233 179 8 37 344
    1597575488350: 2 1 921 70 7 532 5 59 2
    60636199518: 60 7 373 533 4 9 9 9 18
    421157880: 701 92 5 6 42 60
    174249: 54 4 6 2 4 1 22 9 3 90 2 4
    118727669: 76 8 3 6 50 9 18 94 6 3 3
    23125500: 5 3 9 300 571
    1128838032: 59 74 54 1 57 84
    6227: 6 2 1 2 8 1
    13634: 85 2 79 188 7 9
    2594: 9 7 8 131 4
    3244398: 1 52 602 3 534 97
    18391275: 64 79 473 645 6
    197178930620: 293 41 4 4 410 6 6 5 4 7
    1635252: 10 6 81 96 87
    38430183166560: 84 2 91 53 810 8 774
    541205145: 853 6 7 39 9 48
    260245: 4 962 95 66 7
    5585256181: 6 958 54 991 5 3
    2134740037: 3 21 91 6 42 29 6 2 7 7
    2342051: 8 731 7 4 48
    241588625520: 301 686 39 173 5 6 3 2
    5651246579: 253 124 712 79 11 23
    10416: 8 182 608 5 96
    2406: 62 94 16 12 342 1
    1330567: 873 7 18 84 7
    211152912: 47 57 98 86 804
    128953684: 295 23 2 17 41 95 19
    3037977: 5 6 379 36 40
    9013235: 8 3 1 65 2 1 50 9 1 3 35
    2857052260: 3 8 444 7 4 9 1 4 12 62 4
    174249422: 7 15 5 6 24 94 23
    17628: 545 5 4 8 22 6
    856437: 1 874 3 8 513 896 260
    1226796924297: 63 59 205 66 7 23 6 7 6
    581803349533: 2 8 4 29 66 7 8 39 12 7 7
    254021342023: 396 7 2 9 7 6 308 6 5 7 7
    31922147: 316 3 221 4 6
    160080860160: 5 6 7 7 9 5 7 7 85 23 52 3
    350150744: 7 34 9 7 1 4 6 7 9 2 393 6
    513992157: 2 787 3 8 2 55 74
    388382: 8 5 5 23 80 2 9 59 7 2 30
    114598776: 3 3 4 6 7 743 6 608 17 8
    852: 5 6 2 2 818
    51991107: 62 930 107 90 9
    19471914893: 1 432 8 54 63 7 891 1
    14769263: 135 547 60 73 2
    264950665: 98 8 1 4 69 457 970 9 7
    65665642: 67 97 77 52 44
    7086506: 808 4 1 7 102 9 854 14
    2373244: 5 9 315 4 7 1 51 6 47
    2222101: 7 34 148 2 54
    196383915008: 91 65 558 35 20 85 4 7
    1882566840: 77 276 482 68 20 79 7
    3192380: 1 95 1 62 542
    1780325358305: 73 96 5 514 52 70 9 7
    31652: 3 8 6 14 2 23 1 883 4 8 4
    2039767: 4 23 86 942 4
    16443: 1 203 71 508 21
    1525639: 4 39 70 675 4 5 97
    1244447: 85 42 51 2 590 9 9 7 1
    79891266: 23 777 292 57 6 66
    133899684: 1 9 858 51 6 34
    158472: 44 7 118 4 93
    577827: 655 882 8 99 2 8
    26524897: 5 2 2 4 8 2 74 9 4 6 92 5
    619029948: 7 332 718 6 98 6 83 6 2
    21865593: 2 2 315 48 7 68 18 1 3
    59317495: 38 8 195 784 52
    651741664: 49 9 821 2 3 8 3 8 9 2 9 7
    99185020: 495 9 251 4 5
    107005920: 26 3 8 7 7 2 1 4 91 1 672
    2516184: 23 414 9 44 6
    127258624821: 2 9 1 3 209 77 6 482 1
    591136864: 812 728 851 1 11
    7150171: 5 18 6 5 3 5 2 14 1 1 161
    45473775683: 21 7 3 745 23 296 205
    267884545235: 9 8 3 930 6 6 4 98 3 7 9 7
    15888479044: 85 8 5 9 6 932 8 6 1 3 5
    156: 49 5 99
    2274323159: 4 2 8 7 39 50 7 951 2
    75744398: 37 864 8 2 397
    38121863061: 679 185 555 29 795 6
    708: 7 2 685 1 9
    2010678: 268 2 17 7 1 681
    7009005: 48 1 5 8 32 5 9 808 57
    3851784101224: 402 8 7 3 1 98 974 2 1
    70133821172: 273 734 3 35 13 3 172
    2334045177: 3 2 6 3 3 8 4 938 5 3 6 57
    11318244: 16 714 2 120 3 7 5 8 4 7
    1135489: 71 53 978 1 9 239
    97872: 9 35 7 36 70 2 1
    3565690187: 7 9 5 936 853 91 48 59
    27911345: 906 2 4 5 77
    20117244: 425 966 7 7 35 7
    5226102: 4 4 8 9 12 6 2 5 5 3 21 1
    20284677: 22 91 9 75 2 7 2 32 3 63
    59192019234: 8 6 755 56 186 2 2 59 6
    414: 1 48 266
    202496805: 836 193 5 18 251 547
    1756291: 1 76 2 7 7 6 4 2 1 2 3 521
    58130586: 58 1 2 998 9 47 4 42
    185377333373: 9 128 10 51 579 687
    92208192556: 243 937 9 1 39 6 7 718
    70202: 83 845 67
    632631: 79 8 627 1 4
    2308446: 8 62 1 5 3 49 670 2 1 31
    7652167: 7 6 520 79 91
    268204881: 9 3 56 7 976 20 4
    27714632: 6 63 88 6 7 9 467 50
    1199676: 159 26 29 4 629 184
    1168: 53 807 308
    1359889181: 8 5 9 57 62 41 5 1 6 97 9
    43: 5 7 2 4 1
    450410: 33 91 5 77 146
    225806336: 9 5 20 5 7 2 2 2 2 8 4 56
    930622: 92 638 423 2 13
    86493858: 2 158 1 5 90 205 9 2 6 6
    49753745289: 5 5 27 5 7 62 38 2 9 1 9 6
    60371025: 5 95 4 837 46 591 5 75
    3562461: 17 617 609 321 2 1
    145184643: 7 9 3 985 4 757 32 60
    732323: 435 3 7 133 8 4 9 7 2 6 5
    1032885: 679 4 56 7 3 9
    945945: 1 13 86 49 195
    6692478: 97 621 239 39
    12437644755: 238 84 455 5 9 4 551 7
    2886: 703 714 2 8 42
    571: 8 7 9
    1198792: 341 87 14 4 7
    83064502: 281 549 1 64 502
    78565542681: 78 565 542 68 2
    216603: 319 679 4
    337030: 90 1 6 4 93
    225178398: 9 7 6 494 6 25 8 6 5 6 5 3
    359260441: 8 8 4 5 71 11 4 40 3
    7684870400: 68 37 736 166 25
    4836753: 89 6 57 11 124 6 1 9
    448559: 2 3 897 59
    178599251: 5 8 60 5 9 6 2 2 9 38 6 2
    178868: 9 2 75 7 94 922
    28968: 18 8 219 1 71
    13362405963: 7 95 4 76 227 74 17 98
    262350: 795 55 6
    65696728: 6 145 82 397 751
    389312: 81 6 7 7 632
    707357: 4 1 63 30 6 3 50 96 5 7
    19717: 1 42 55 1 7
    20394032681: 5 122 79 5 1 2 1 9 1 28 2
    4784: 2 8 9 6 12 41 8 2 6 516 4
    1609910: 1 37 614 69
    523221: 962 4 70 7 1 5 64 6 99 6
    6181619: 77 9 892 6 53
    213398378: 26 7 872 63 47 77
    1283136751: 1 26 32 6 1 41 6 750 7
    437556672: 518 2 36 14 838
    2050513997: 50 41 51 399 7
    669844: 66 89 86 1 858
    163612855: 78 64 75 437 5 50
    1153638940155: 282 8 671 5 63 3 9 965
    147012685: 639 23 4 264 7 18 18
    41376667393: 628 94 77 524 83 7 4 8
    48762054: 5 11 9 58 9 6 1 7 6 618 9
    31668453: 9 951 37 59 94
    2668647: 347 93 262 82 940 1
    75501141: 5 807 72 6 130
    3054130: 3 31 821 4 1 9
    118264252: 722 25 819 59 8 180
    212285289: 60 5 35 6 64 2 9 9 3 3
    102104550993: 29 5 8 6 2 5 9 850 7 4 9 1
    1640167: 16 39 24 92 4 5
    454855747068: 827 55 574 625 81 8
    101649: 607 164 868 62 31
    586: 8 27 4 6 4
    1995211: 1 82 117 5 210
    6293: 86 870 91 6 10
    173274931255: 773 5 476 3 9 56 13 4 3
    979213568: 450 64 2 2 2 54 144 17
    228477312: 4 977 87 672
    1958906346: 6 529 6 811 65 1 1 3 6 1
    3982693130574: 66 93 60 19 595 74
    113280: 385 8 7 81 8 5 1 1
    176418: 9 1 27 121 6
    483888323: 2 3 8 3 8 8 741 90 8 1 6
    125276: 4 5 533 231 73
    2031843: 502 9 994 27 4
    181636303883: 920 3 3 1 6 7 94 1 4 7 8 2
    11711860: 2 8 89 8 70 3 2 36 862
    42810645671: 828 70 861 6 6 70
    32393: 3 18 14 5 11
    142818114700932: 6 98 46 885 3 6 88 2 2 6
    80412: 5 23 291 787 9
    5756790: 8 3 4 21 31 919 6 5 89
    30328450223: 3 9 12 2 8 4 9 8 5 5 1 226
    1152: 60 4 3 2 3
    926: 1 456 7 2
    2560803: 3 77 8 4 803
    259920: 5 5 192 6 543 50 4 9 1 4
    40430292: 2 139 6 6 416 75 2 21
    3058611251: 942 2 20 3 54 51 252
    371442757: 54 8 901 78 278 875 8
    1976: 24 2 76
    17440633: 253 173 8 2 5 8 634
    10894: 7 996 4 855 5
    1026899793: 3 2 9 2 2 3 91 4 249 49 4
    9527619: 9 943 710 2 2 8 510
    16018794: 4 86 597 78 90
    220925803882: 517 2 7 60 828 5 6 26 7
    2781157936: 235 74 9 153 4 23 70 6
    5345188071954: 962 923 45 61 6 5 91
    2498015: 356 859 7
    499591377: 42 3 19 539 3 9 699 1
    1090215: 5 3 57 45 7
    15519652344: 23 10 4 24 84 90 9 7 72
    907143: 3 6 90 97 1 4 6
    117077387: 9 5 2 3 1 9 9 9 550 346 4
    18354138559: 32 20 57 7 6 8 55 1 2 4
    275237: 9 23 114 77 2 687 437
    214176: 8 335 9 36 138 4
    2089632912: 74 51 7 83 8 4 813 97
    19904427: 8 7 196 8 1 53 9 5 2 7
    308810886: 222 21 69 96 3
    132301: 6 14 1 47 294 7
    25284884: 43 84 7 8 79 3
    1155: 552 50 73 430 50
    250971: 1 296 55 715 6
    5544: 84 3 22
    36731: 47 20 71 59 3 62 89
    801108: 153 77 68
    1846900: 95 2 970 10 2
    2041: 5 73 1 2 4 6 8 6 2 9 3 52
    29295248: 4 6 62 34 1 4 51 6 5 3 4 6
    6911470: 15 23 57 2 68
    17332770: 92 8 8 9 6 1 16 7 14 39
    12908392: 4 7 75 7 474 9 6 4 8 9 9 2
    732368: 653 8 3 1 7 9 5 4 90 5 3 4
    107000: 377 19 25 799 5 5
    609810: 7 2 44 7 9 713 92 5
    34492227: 9 7 993 77 7 3
    1351: 2 597 1 78 78 1
    32345: 9 908 7 50 5
    17411670783: 80 147 90 139 1 6 764
    477603: 55 24 397 4 623 7 27
    3177414: 317 7 395 8 9
    1464027960: 7 742 4 3 3 3 20 9 7 3 3 1
    338846: 33 270 2 5 38
    1289680998: 515 872 4 250
    206989: 3 70 5 81 4 7 6
    410915: 8 8 5 63 50 949
    16407452695: 95 95 57 3 185 84 4 4
    241574: 22 4 8 3 2 55 36 3 3 53
    5815: 8 7 949 8 4 6 899 856
    132336722: 292 9 513 91 148 421
    33640: 7 50 6 499 40
    487790318: 97 5 3 6 8 615 31 3 9 6 2
    1191828: 116 3 177 1 57
    1419906212: 3 99 7 6 41 86 1 94 7 7 8
    1096940: 11 78 150 1 826 12
    12634809: 126 33 110 868 828
    13938175: 9 15 13 425 17 2
    26174932: 749 399 5 4 3 5 1 6 1 76
    24376672: 4 90 8 4 46 6 1 46 69 7
    636: 59 1 91 9 4
    3318871: 713 8 30 207 9 5 2 2 8 3
    787624929631: 984 531 161 8 8 31
    1632805574: 5 6 5 5 1 8 7 6 461 2 94 5
    10582: 4 343 4 9 731 5
    1181968602: 555 31 2 47 2 9 7 860 1
    521044974: 3 17 973 123 9 474
    4540536945: 100 84 858 6 5 44 3 3 7
    2303: 3 93 9 8
    549077983: 6 908 60 52 997 6
    349510: 3 587 66 1 126 3 451
    48428832716: 751 89 363 641 713
    10481558632: 3 7 481 55 8 630
    581225299324: 81 75 1 2 91 876 6 1 24
    """;

    [TestCase(TestInput, "3749")]
    public void Part1(string input, string expectedOutput)
    {
        var testOutput = Solution1(input);
        Console.WriteLine($"{nameof(Part1)} test result: {testOutput}");
        Assert.That(testOutput, Is.EqualTo(expectedOutput));

        // only executed if the test input worked
        var actualOutput = Solution1(Input);
        Console.WriteLine($"{nameof(Part1)} actual result: {actualOutput}");
    }

    [TestCase(TestInput, "11387")]
    public void Part2(string input, string expectedOutput)
    {
        var testOutput = Solution2(input);
        Console.WriteLine($"{nameof(Part2)} test result: {testOutput}");
        Assert.That(testOutput, Is.EqualTo(expectedOutput));

        // only executed if the test input worked
        var actualOutput = Solution2(Input);
        Console.WriteLine($"{nameof(Part2)} actual result: {actualOutput}");
    }

    private static string Solution1(string input)
    {
        var lines = input.Split('\n')
            .Select(line => line.Trim())
            .ToList();

        long result1 = 0;
        foreach (var line in lines)
        {
            var split = line.Split(":");
            var left = long.Parse(split[0].Trim());
            var right = split[1].Trim()
                .Split(' ')
                .Select(long.Parse)
                .ToList();

            var operandsCount = right.Count - 1;
            var from = Convert.ToInt64(new string('0', operandsCount), 2);
            var to = Convert.ToInt64(new string('1', operandsCount), 2);

            while (from <= to)
            {
                var tmp = right[0];
                var operands = Convert
                    .ToString(from, 2);

                operands = operands.PadLeft(operandsCount, '0');

                for (var i = 1; i < right.Count; i++)
                {
                    if (operands[i - 1] == '0')
                    {
                        tmp *= right[i];
                    }
                    else
                    {
                        tmp += right[i];
                    }
                }

                if (tmp == left)
                {
                    result1 += left;
                    break;
                }

                from++;
            }
        }
        
        return result1.ToString();
    }

    private static string Solution2(string input)
    {
        var lines = input.Split('\n')
            .Select(line => line.Trim())
            .ToList();

        long result2 = 0;
        foreach (var line in lines)
        {
            var split = line.Split(":");
            var left = long.Parse(split[0].Trim());
            var right = split[1].Trim()
                .Split(' ')
                .Select(long.Parse)
                .ToList();

            var operandsCount = right.Count - 1;

            var from = 0;
            var to = 1;
            for (var i = 0; i < operandsCount; i++)
            {
                to *= 3;
            }

            while (from <= to)
            {
                var operands = ConvertFromDecimal(from).PadLeft(operandsCount, '0');

                operands = operands.PadLeft(operandsCount, '0');

                var tmp = right[0];
                for (var i = 1; i < right.Count; i++)
                {
                    if (operands[i - 1] == '0')
                    {
                        tmp *= right[i];
                    }
                    else if (operands[i - 1] == '1')
                    {
                        tmp += right[i];
                    }
                    else
                    {
                        tmp = long.Parse(tmp.ToString() + right[i]);
                    }
                }

                if (tmp == left)
                {
                    result2 += left;
                    break;
                }

                from++;
            }
        }

        return result2.ToString();
    }

    static string ConvertFromDecimal(long number, long toBase = 3)
    {
        var quotient = number;
        var sb = new StringBuilder();
        do
        {
            var remainder = quotient % toBase;
            quotient = quotient / toBase;
            sb.Insert(0, remainder);

        } while (quotient != 0);

        return sb.ToString();
    }
}