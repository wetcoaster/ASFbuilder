using System;
using System.Collections.Generic;
using ASFbuilder.Equipment;

namespace ASFbuilder.Data
{
    // Hard coded data to be used by default if external equipment file is not found
    static class Engine
    {
        public static List<Equipment.Engine> populateSFE()
        {
            List<Equipment.Engine> engines = new List<Equipment.Engine>();
            engines.Add(new Equipment.Engine(10, 0.5m, "0  Standard", "SFE"));
            engines.Add(new Equipment.Engine(15, 0.5m, "15  Standard", "SFE"));
            engines.Add(new Equipment.Engine(20, 0.5m, "20  Standard", "SFE"));
            engines.Add(new Equipment.Engine(25, 0.5m, "25  Standard", "SFE"));
            engines.Add(new Equipment.Engine(30, 1.0m, "30  Standard", "SFE"));
            engines.Add(new Equipment.Engine(35, 1.0m, "35  Standard", "SFE"));
            engines.Add(new Equipment.Engine(40, 1.0m, "40  Standard", "SFE"));
            engines.Add(new Equipment.Engine(45, 1.0m, "45  Standard", "SFE"));
            engines.Add(new Equipment.Engine(50, 1.5m, "50  Standard", "SFE"));
            engines.Add(new Equipment.Engine(55, 1.5m, "55  Standard", "SFE"));
            engines.Add(new Equipment.Engine(60, 1.5m, "60  Standard", "SFE"));
            engines.Add(new Equipment.Engine(65, 2.0m, "65  Standard", "SFE"));
            engines.Add(new Equipment.Engine(70, 2.0m, "70  Standard", "SFE"));
            engines.Add(new Equipment.Engine(75, 2.0m, "75  Standard", "SFE"));
            engines.Add(new Equipment.Engine(80, 2.5m, "80  Standard", "SFE"));
            engines.Add(new Equipment.Engine(85, 2.5m, "85  Standard", "SFE"));
            engines.Add(new Equipment.Engine(90, 3.0m, "90  Standard", "SFE"));
            engines.Add(new Equipment.Engine(95, 3.0m, "95  Standard", "SFE"));
            engines.Add(new Equipment.Engine(100, 3.0m, "100 Standard", "SFE"));

            engines.Add(new Equipment.Engine(105, 3.5m, "100 Standard", "SFE"));
            engines.Add(new Equipment.Engine(110, 3.5m, "110 Standard", "SFE"));
            engines.Add(new Equipment.Engine(115, 4.0m, "115 Standard", "SFE"));
            engines.Add(new Equipment.Engine(120, 4.0m, "120 Standard", "SFE"));
            engines.Add(new Equipment.Engine(125, 4.0m, "125 Standard", "SFE"));
            engines.Add(new Equipment.Engine(130, 4.5m, "130 Standard", "SFE"));
            engines.Add(new Equipment.Engine(135, 4.5m, "135 Standard", "SFE"));
            engines.Add(new Equipment.Engine(140, 5.0m, "140 Standard", "SFE"));
            engines.Add(new Equipment.Engine(145, 5.0m, "145 Standard", "SFE"));
            engines.Add(new Equipment.Engine(150, 5.5m, "150 Standard", "SFE"));
            engines.Add(new Equipment.Engine(155, 5.5m, "155 Standard", "SFE"));
            engines.Add(new Equipment.Engine(160, 6.0m, "160 Standard", "SFE"));
            engines.Add(new Equipment.Engine(165, 6.0m, "165 Standard", "SFE"));
            engines.Add(new Equipment.Engine(170, 6.0m, "170 Standard", "SFE"));
            engines.Add(new Equipment.Engine(175, 7.0m, "175 Standard", "SFE"));
            engines.Add(new Equipment.Engine(180, 7.0m, "180 Standard", "SFE"));
            engines.Add(new Equipment.Engine(185, 7.5m, "185 Standard", "SFE"));
            engines.Add(new Equipment.Engine(190, 7.5m, "190 Standard", "SFE"));
            engines.Add(new Equipment.Engine(195, 8.0m, "195 Standard", "SFE"));
            engines.Add(new Equipment.Engine(200, 8.5m, "200 Standard", "SFE"));

            engines.Add(new Equipment.Engine(205, 8.5m, "205 Standard", "SFE"));
            engines.Add(new Equipment.Engine(210, 9.0m, "210 Standard", "SFE"));
            engines.Add(new Equipment.Engine(215, 9.5m, "215 Standard", "SFE"));
            engines.Add(new Equipment.Engine(220, 10.0m, "220 Standard", "SFE"));
            engines.Add(new Equipment.Engine(225, 10.0m, "225 Standard", "SFE"));
            engines.Add(new Equipment.Engine(230, 10.5m, "230 Standard", "SFE"));
            engines.Add(new Equipment.Engine(235, 11.0m, "235 Standard", "SFE"));
            engines.Add(new Equipment.Engine(240, 11.5m, "240 Standard", "SFE"));
            engines.Add(new Equipment.Engine(245, 12.0m, "245 Standard", "SFE"));
            engines.Add(new Equipment.Engine(250, 12.5m, "250 Standard", "SFE"));
            engines.Add(new Equipment.Engine(255, 13.0m, "255 Standard", "SFE"));
            engines.Add(new Equipment.Engine(260, 13.5m, "260 Standard", "SFE"));
            engines.Add(new Equipment.Engine(265, 14.0m, "265 Standard", "SFE"));
            engines.Add(new Equipment.Engine(270, 14.5m, "270 Standard", "SFE"));
            engines.Add(new Equipment.Engine(275, 15.5m, "275 Standard", "SFE"));
            engines.Add(new Equipment.Engine(280, 16.0m, "280 Standard", "SFE"));
            engines.Add(new Equipment.Engine(285, 16.5m, "285 Standard", "SFE"));
            engines.Add(new Equipment.Engine(290, 17.5m, "290 Standard", "SFE"));
            engines.Add(new Equipment.Engine(295, 18.0m, "295 Standard", "SFE"));
            engines.Add(new Equipment.Engine(300, 19.0m, "300 Standard", "SFE"));

            engines.Add(new Equipment.Engine(305, 19.5m, "305 Standard", "SFE"));
            engines.Add(new Equipment.Engine(310, 20.5m, "310 Standard", "SFE"));
            engines.Add(new Equipment.Engine(315, 21.5m, "315 Standard", "SFE"));
            engines.Add(new Equipment.Engine(320, 22.5m, "320 Standard", "SFE"));
            engines.Add(new Equipment.Engine(325, 23.5m, "325 Standard", "SFE"));
            engines.Add(new Equipment.Engine(330, 24.5m, "330 Standard", "SFE"));
            engines.Add(new Equipment.Engine(335, 25.5m, "335 Standard", "SFE"));
            engines.Add(new Equipment.Engine(340, 27.0m, "340 Standard", "SFE"));
            engines.Add(new Equipment.Engine(345, 28.5m, "345 Standard", "SFE"));
            engines.Add(new Equipment.Engine(350, 29.5m, "350 Standard", "SFE"));
            engines.Add(new Equipment.Engine(355, 31.5m, "355 Standard", "SFE"));
            engines.Add(new Equipment.Engine(360, 33.0m, "360 Standard", "SFE"));
            engines.Add(new Equipment.Engine(365 ,34.5m, "365 Standard", "SFE"));
            engines.Add(new Equipment.Engine(370, 36.5m, "370 Standard", "SFE"));
            engines.Add(new Equipment.Engine(375, 38.5m, "375 Standard", "SFE"));
            engines.Add(new Equipment.Engine(380, 41.0m, "380 Standard", "SFE"));
            engines.Add(new Equipment.Engine(385, 43.5m, "385 Standard", "SFE"));
            engines.Add(new Equipment.Engine(390, 46.0m, "390 Standard", "SFE"));
            engines.Add(new Equipment.Engine(395, 49.0m, "395 Standard", "SFE"));
            engines.Add(new Equipment.Engine(400, 52.5m, "400 Standard", "SFE"));
            return engines;
        }

        public static List<Equipment.Engine> populateXLFE()
        {
            List<Equipment.Engine> engines = new List<Equipment.Engine>();
            engines.Add(new Equipment.Engine(10, 0.5m, "10  XL", "XL"));
            engines.Add(new Equipment.Engine(15, 0.5m, "15  XL", "XL"));
            engines.Add(new Equipment.Engine(20, 0.5m, "20  XL", "XL"));
            engines.Add(new Equipment.Engine(25, 0.5m, "25  XL", "XL"));
            engines.Add(new Equipment.Engine(30, 0.5m, "30  XL", "XL"));
            engines.Add(new Equipment.Engine(35, 0.5m, "35  XL", "XL"));
            engines.Add(new Equipment.Engine(40, 0.5m, "40  XL", "XL"));
            engines.Add(new Equipment.Engine(45, 0.5m, "45  XL", "XL"));
            engines.Add(new Equipment.Engine(50, 1.0m, "50  XL", "XL"));
            engines.Add(new Equipment.Engine(55, 1.0m, "55  XL", "XL"));
            engines.Add(new Equipment.Engine(60, 1.0m, "60  XL", "XL"));
            engines.Add(new Equipment.Engine(65, 1.0m, "65  XL", "XL"));
            engines.Add(new Equipment.Engine(70, 1.0m, "70  XL", "XL"));
            engines.Add(new Equipment.Engine(75, 1.0m, "75  XL", "XL"));
            engines.Add(new Equipment.Engine(80, 1.5m, "80  XL", "XL"));
            engines.Add(new Equipment.Engine(85, 1.5m, "85  XL", "XL"));
            engines.Add(new Equipment.Engine(90, 1.5m, "90  XL", "XL"));
            engines.Add(new Equipment.Engine(95, 1.5m, "95  XL", "XL"));
            engines.Add(new Equipment.Engine(100, 1.5m, "100 XL", "XL"));

            engines.Add(new Equipment.Engine(105, 2.0m, "105 XL", "XL"));
            engines.Add(new Equipment.Engine(110, 2.0m, "110 XL", "XL"));
            engines.Add(new Equipment.Engine(115, 2.0m, "115 XL", "XL"));
            engines.Add(new Equipment.Engine(120, 2.0m, "120 XL", "XL"));
            engines.Add(new Equipment.Engine(125, 2.0m, "125 XL", "XL"));
            engines.Add(new Equipment.Engine(130, 2.5m, "130 XL", "XL"));
            engines.Add(new Equipment.Engine(135, 2.5m, "135 XL", "XL"));
            engines.Add(new Equipment.Engine(140, 2.5m, "140 XL", "XL"));
            engines.Add(new Equipment.Engine(145, 3.0m, "145 XL", "XL"));
            engines.Add(new Equipment.Engine(150, 3.0m, "150 XL", "XL"));
            engines.Add(new Equipment.Engine(155, 3.0m, "155 XL", "XL"));
            engines.Add(new Equipment.Engine(160, 3.0m, "160 XL", "XL"));
            engines.Add(new Equipment.Engine(165, 3.0m, "165 XL", "XL"));
            engines.Add(new Equipment.Engine(170, 3.0m, "170 XL", "XL"));
            engines.Add(new Equipment.Engine(175, 3.5m, "175 XL", "XL"));
            engines.Add(new Equipment.Engine(180, 3.5m, "180 XL", "XL"));
            engines.Add(new Equipment.Engine(185, 4.0m, "185 XL", "XL"));
            engines.Add(new Equipment.Engine(190, 4.0m, "190 XL", "XL"));
            engines.Add(new Equipment.Engine(195, 4.0m, "195 XL", "XL"));
            engines.Add(new Equipment.Engine(200, 4.5m, "200 XL", "XL"));

            engines.Add(new Equipment.Engine(205, 4.5m, "205 XL", "XL"));
            engines.Add(new Equipment.Engine(210, 4.5m, "210 XL", "XL"));
            engines.Add(new Equipment.Engine(215, 5.0m, "215 XL", "XL"));
            engines.Add(new Equipment.Engine(220, 5.0m, "220 XL", "XL"));
            engines.Add(new Equipment.Engine(225, 5.0m, "225 XL", "XL"));
            engines.Add(new Equipment.Engine(230, 5.5m, "230 XL", "XL"));
            engines.Add(new Equipment.Engine(235, 5.5m, "235 XL", "XL"));
            engines.Add(new Equipment.Engine(240, 6.0m, "240 XL", "XL"));
            engines.Add(new Equipment.Engine(245, 6.0m, "245 XL", "XL"));
            engines.Add(new Equipment.Engine(250, 6.5m, "250 XL", "XL"));
            engines.Add(new Equipment.Engine(255, 6.5m, "255 XL", "XL"));
            engines.Add(new Equipment.Engine(260, 7.0m, "260 XL", "XL"));
            engines.Add(new Equipment.Engine(265, 7.0m, "265 XL", "XL"));
            engines.Add(new Equipment.Engine(270, 7.5m, "270 XL", "XL"));
            engines.Add(new Equipment.Engine(275, 8.0m, "275 XL", "XL"));
            engines.Add(new Equipment.Engine(280, 8.0m, "280 XL", "XL"));
            engines.Add(new Equipment.Engine(285, 8.5m, "285 XL", "XL"));
            engines.Add(new Equipment.Engine(290, 9.0m, "290 XL", "XL"));
            engines.Add(new Equipment.Engine(295, 9.0m, "295 XL", "XL"));
            engines.Add(new Equipment.Engine(300, 9.5m, "300 XL", "XL"));

            engines.Add(new Equipment.Engine(305, 10.0m, "305 XL", "XL"));
            engines.Add(new Equipment.Engine(310, 10.5m, "310 XL", "XL"));
            engines.Add(new Equipment.Engine(315, 11.0m, "315 XL", "XL"));
            engines.Add(new Equipment.Engine(320, 11.5m, "320 XL", "XL"));
            engines.Add(new Equipment.Engine(325, 12.0m, "325 XL", "XL"));
            engines.Add(new Equipment.Engine(330, 12.5m, "330 XL", "XL"));
            engines.Add(new Equipment.Engine(335, 13.0m, "335 XL", "XL"));
            engines.Add(new Equipment.Engine(340, 13.5m, "340 XL", "XL"));
            engines.Add(new Equipment.Engine(345, 14.5m, "345 XL", "XL"));
            engines.Add(new Equipment.Engine(350, 15.0m, "350 XL", "XL"));
            engines.Add(new Equipment.Engine(355, 16.0m, "355 XL", "XL"));
            engines.Add(new Equipment.Engine(360, 16.5m, "360 XL", "XL"));
            engines.Add(new Equipment.Engine(365, 17.5m, "365 XL", "XL"));
            engines.Add(new Equipment.Engine(370, 18.5m, "370 XL", "XL"));
            engines.Add(new Equipment.Engine(375, 19.5m, "375 XL", "XL"));
            engines.Add(new Equipment.Engine(380, 20.5m, "380 XL", "XL"));
            engines.Add(new Equipment.Engine(385, 22.0m, "385 XL", "XL"));
            engines.Add(new Equipment.Engine(390, 23.0m, "390 XL", "XL"));
            engines.Add(new Equipment.Engine(395, 24.5m, "395 XL", "XL"));
            engines.Add(new Equipment.Engine(400, 26.5m, "400 XL", "XL"));
            return engines;
        }

        public static List<Equipment.Engine> populateLFE()
        {
            List<Equipment.Engine> engines = new List<Equipment.Engine>();
            engines.Add(new Equipment.Engine(10, 0.5m, "10  Light", "LFE"));
            engines.Add(new Equipment.Engine(15, 0.5m, "15  Light", "LFE"));
            engines.Add(new Equipment.Engine(20, 0.5m, "20  Light", "LFE"));
            engines.Add(new Equipment.Engine(25, 0.5m, "25  Light", "LFE"));
            engines.Add(new Equipment.Engine(30, 1.0m, "30  Light", "LFE"));
            engines.Add(new Equipment.Engine(35, 1.0m, "35  Light", "LFE"));
            engines.Add(new Equipment.Engine(40, 1.0m, "40  Light", "LFE"));
            engines.Add(new Equipment.Engine(45, 1.0m, "45  Light", "LFE"));
            engines.Add(new Equipment.Engine(50, 1.5m, "50  Light", "LFE"));
            engines.Add(new Equipment.Engine(55, 1.5m, "55  Light", "LFE"));
            engines.Add(new Equipment.Engine(60, 1.5m, "60  Light", "LFE"));
            engines.Add(new Equipment.Engine(65, 1.5m, "65  Light", "LFE"));
            engines.Add(new Equipment.Engine(70, 1.5m, "70  Light", "LFE"));
            engines.Add(new Equipment.Engine(75, 1.5m, "75  Light", "LFE"));
            engines.Add(new Equipment.Engine(80, 2.0m, "80  Light", "LFE"));
            engines.Add(new Equipment.Engine(85, 2.0m, "85  Light", "LFE"));
            engines.Add(new Equipment.Engine(90, 2.5m, "90  Light", "LFE"));
            engines.Add(new Equipment.Engine(95, 2.5m, "95  Light", "LFE"));
            engines.Add(new Equipment.Engine(100, 2.5m, "100 Light", "LFE"));

            engines.Add(new Equipment.Engine(105, 3.0m, "105 Light", "LFE"));
            engines.Add(new Equipment.Engine(110, 3.0m, "110 Light", "LFE"));
            engines.Add(new Equipment.Engine(115, 3.0m, "115 Light", "LFE"));
            engines.Add(new Equipment.Engine(120, 3.0m, "120 Light", "LFE"));
            engines.Add(new Equipment.Engine(125, 3.0m, "125 Light", "LFE"));
            engines.Add(new Equipment.Engine(130, 3.5m, "130 Light", "LFE"));
            engines.Add(new Equipment.Engine(135, 3.5m, "135 Light", "LFE"));
            engines.Add(new Equipment.Engine(140, 4.0m, "140 Light", "LFE"));
            engines.Add(new Equipment.Engine(145, 4.0m, "145 Light", "LFE"));
            engines.Add(new Equipment.Engine(150, 4.5m, "150 Light", "LFE"));
            engines.Add(new Equipment.Engine(155, 4.5m, "155 Light", "LFE"));
            engines.Add(new Equipment.Engine(160, 4.5m, "160 Light", "LFE"));
            engines.Add(new Equipment.Engine(165, 4.5m, "165 Light", "LFE"));
            engines.Add(new Equipment.Engine(170, 4.5m, "170 Light", "LFE"));
            engines.Add(new Equipment.Engine(175, 5.5m, "175 Light", "LFE"));
            engines.Add(new Equipment.Engine(180, 5.5m, "180 Light", "LFE"));
            engines.Add(new Equipment.Engine(185, 6.0m, "185 Light", "LFE"));
            engines.Add(new Equipment.Engine(190, 6.0m, "190 Light", "LFE"));
            engines.Add(new Equipment.Engine(195, 6.0m, "195 Light", "LFE"));
            engines.Add(new Equipment.Engine(200, 6.5m, "200 Light", "LFE"));

            engines.Add(new Equipment.Engine(205, 6.5m, "205 Light", "LFE"));
            engines.Add(new Equipment.Engine(210, 7.0m, "210 Light", "LFE"));
            engines.Add(new Equipment.Engine(215, 7.5m, "215 Light", "LFE"));
            engines.Add(new Equipment.Engine(220, 7.5m, "220 Light", "LFE"));
            engines.Add(new Equipment.Engine(225, 7.5m, "225 Light", "LFE"));
            engines.Add(new Equipment.Engine(230, 8.0m, "230 Light", "LFE"));
            engines.Add(new Equipment.Engine(235, 8.5m, "235 Light", "LFE"));
            engines.Add(new Equipment.Engine(240, 9.0m, "240 Light", "LFE"));
            engines.Add(new Equipment.Engine(245, 9.0m, "245 Light", "LFE"));
            engines.Add(new Equipment.Engine(250, 9.5m, "250 Light", "LFE"));
            engines.Add(new Equipment.Engine(255, 10.0m, "255 Light", "LFE"));
            engines.Add(new Equipment.Engine(260, 10.5m, "260 Light", "LFE"));
            engines.Add(new Equipment.Engine(265, 10.5m, "265 Light", "LFE"));
            engines.Add(new Equipment.Engine(270, 11.0m, "270 Light", "LFE"));
            engines.Add(new Equipment.Engine(275, 12.0m, "275 Light", "LFE"));
            engines.Add(new Equipment.Engine(280, 12.0m, "280 Light", "LFE"));
            engines.Add(new Equipment.Engine(285, 12.5m, "285 Light", "LFE"));
            engines.Add(new Equipment.Engine(290, 13.5m, "290 Light", "LFE"));
            engines.Add(new Equipment.Engine(295, 13.5m, "295 Light", "LFE"));
            engines.Add(new Equipment.Engine(300, 14.5m, "300 Light", "LFE"));

            engines.Add(new Equipment.Engine(305, 15.0m, "305 Light", "LFE"));
            engines.Add(new Equipment.Engine(310, 15.5m, "310 Light", "LFE"));
            engines.Add(new Equipment.Engine(315, 16.5m, "315 Light", "LFE"));
            engines.Add(new Equipment.Engine(320, 17.0m, "320 Light", "LFE"));
            engines.Add(new Equipment.Engine(325, 18.0m, "325 Light", "LFE"));
            engines.Add(new Equipment.Engine(330, 18.5m, "330 Light", "LFE"));
            engines.Add(new Equipment.Engine(335, 19.5m, "335 Light", "LFE"));
            engines.Add(new Equipment.Engine(340, 20.5m, "340 Light", "LFE"));
            engines.Add(new Equipment.Engine(345, 21.5m, "345 Light", "LFE"));
            engines.Add(new Equipment.Engine(350, 22.5m, "350 Light", "LFE"));
            engines.Add(new Equipment.Engine(355, 24.0m, "355 Light", "LFE"));
            engines.Add(new Equipment.Engine(360, 25.0m, "360 Light", "LFE"));
            engines.Add(new Equipment.Engine(365, 26.0m, "365 Light", "LFE"));
            engines.Add(new Equipment.Engine(370, 27.5m, "370 Light", "LFE"));
            engines.Add(new Equipment.Engine(375, 29.5m, "375 Light", "LFE"));
            engines.Add(new Equipment.Engine(380, 31.0m, "380 Light", "LFE"));
            engines.Add(new Equipment.Engine(385, 33.0m, "385 Light", "LFE"));
            engines.Add(new Equipment.Engine(390, 34.5m, "390 Light", "LFE"));
            engines.Add(new Equipment.Engine(395, 37.0m, "395 Light", "LFE"));
            engines.Add(new Equipment.Engine(400, 39.5m, "400 Light", "LFE"));
            return engines;
        }
    }
}