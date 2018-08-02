/**
 * @license ResponsiveVoice JS v1.5.8
 *
 * (c) 2015-2018 LearnBrite
 *
 * License: http://responsivevoice.org/license
 */

if (typeof responsiveVoice != 'undefined') {
    console.log('ResponsiveVoice already loaded');
    console.log(responsiveVoice);
} else {

    var ResponsiveVoice = function () {

        var self = this;

        self.version = "1.5.8";
        console.log("ResponsiveVoice r" + self.version);

        // Our own collection of voices
        self.responsivevoices = [
            {name: 'UK English Female', flag: 'gb', gender: 'f', voiceIDs: [3, 7, 171, 278, 201, 5, 1, 257, 286, 342, 258, 287, 343, 8]},
            {name: 'UK English Male', flag: 'gb', gender: 'm', voiceIDs: [0, 277, 202, 75, 4, 2, 256, 285, 341, 159, 6, 7]},
            {name: 'US English Female', flag: 'us', gender: 'f', voiceIDs: [39, 40, 41, 42, 383, 205, 204, 43, 173, 235, 283, 339, 44]},
            {name: 'US English Male', flag: 'us', gender: 'm', voiceIDs: [234, 282, 338, 236, 284, 340, 237, 382, 2, 4, 0, 6, 7, 75, 159]},//[195,169]}, original service is (temporary?) down
            {name: 'Arabic Male', flag: 'ar', gender: 'm', voiceIDs: [96, 95, 97, 196, 388]},
            {name: 'Arabic Female', flag: 'ar', gender: 'f', voiceIDs: [98]},
            {name: 'Armenian Male', flag: 'hy', gender: 'f', voiceIDs: [99]},
            {name: 'Australian Female', flag: 'au', gender: 'f', voiceIDs: [276,201,87,5,88]},
            {name: 'Australian Male', flag: 'au', gender: 'm', voiceIDs: [86, 381, 386]},
            {name: 'Brazilian Portuguese Female', flag: 'br', gender: 'f', voiceIDs: [245,124,123,125,186,223,126]},
            {name: 'Brazilian Portuguese Male', flag: 'br', gender: 'm', voiceIDs: [315, 332, 371, 399]},
            {name: 'Chinese Female', flag: 'cn', gender: 'f', voiceIDs: [249, 58, 59, 380, 281, 231, 155, 60, 191, 268, 297, 353, 269, 298, 354, 61]},
            {name: 'Chinese Male', flag: 'cn', gender: 'm', voiceIDs: [317, 334, 373, 389]},
            {name: 'Chinese (Hong Kong) Female', flag: 'hk', gender: 'f', voiceIDs: [192, 193, 232, 250, 251, 270, 299, 355, 252]},
            {name: 'Chinese (Hong Kong) Male', flag: 'hk', gender: 'm', voiceIDs: [318, 335, 374, 390]},
            {name: 'Chinese Taiwan Female', flag: 'tw', gender: 'f', voiceIDs: [194, 233, 253, 254, 305, 322, 361, 384, 319, 336, 375, 255]},
            {name: 'Chinese Taiwan Male', flag: 'tw', gender: 'm', voiceIDs: [320, 337, 376, 391]},
            {name: 'Czech Female', flag: 'cz', gender: 'f', voiceIDs: [101,100,102,197,103]},
            {name: 'Czech Male', flag: 'cz', gender: 'm', voiceIDs: [161]},	
            {name: 'Danish Female', flag: 'dk', gender: 'f', voiceIDs: [105,104,106,198,107]},
            {name: 'Danish Male', flag: 'da', gender: 'm', voiceIDs: [162]},
            {name: 'Deutsch Female', flag: 'de', gender: 'f', voiceIDs: [27, 28, 29, 30, 78, 170, 275, 199, 31, 261, 290, 346, 262, 291, 347, 32]},
            {name: 'Deutsch Male', flag: 'de', gender: 'm', voiceIDs: [307, 324, 363, 377, 393]},
            {name: 'Dutch Female', flag: 'nl', gender: 'f', voiceIDs: [243, 219, 84, 157, 158, 184, 45]},
            {name: 'Dutch Male', flag: 'nl', gender: 'm', voiceIDs: [157, 220, 407]},
            {name: 'Finnish Female', flag: 'fi', gender: 'f', voiceIDs: [90,89,91,209,92]},
            {name: 'Finnish Male', flag: 'fi', gender: 'm', voiceIDs: [160]},	
            {name: 'French Female', flag: 'fr', gender: 'f', voiceIDs: [240, 21, 22, 23, 77, 178, 279, 210,266,295,351,304,321,360,26]},
            {name: 'French Male', flag: 'fr', gender: 'm', voiceIDs: [311, 328, 367, 378, 392]},
            {name: 'Greek Female', flag: 'gr', gender: 'f', voiceIDs: [62, 63, 80, 200,64]},
            {name: 'Greek Male', flag: 'gr', gender: 'm', voiceIDs: [163]},	
            // {name: 'Haitian Creole Female', flag: 'ht', gender: 'f', voiceIDs: [109]}, //DEPRECATED - NO LONGER SUPPORTED
            {name: 'Hindi Female', flag: 'hi', gender: 'f', voiceIDs: [247, 66, 154, 179, 213, 259, 288, 344, 67]},
            {name: 'Hindi Male', flag: 'hi', gender: 'm', voiceIDs: [394]},
            {name: 'Hungarian Female', flag: 'hu', gender: 'f', voiceIDs: [9, 10, 81,214, 11]},
            {name: 'Hungarian Male', flag: 'hu', gender: 'm', voiceIDs: [164]},	
            {name: 'Indonesian Female', flag: 'id', gender: 'f', voiceIDs: [241, 111,112,180,215,113]},
            {name: 'Indonesian Male', flag: 'id', gender: 'm', voiceIDs: [395]},
            {name: 'Italian Female', flag: 'it', gender: 'f', voiceIDs: [242, 33, 34, 35, 36, 37, 79, 181, 216, 271, 300, 356, 38]},
            {name: 'Italian Male', flag: 'it', gender: 'm', voiceIDs: [312, 329, 368, 406]},
            {name: 'Japanese Female', flag: 'jp', gender: 'f', voiceIDs: [248, 50, 51, 280, 217, 52, 153, 182, 273, 302, 358, 274, 303, 359, 53]},
            {name: 'Japanese Male', flag: 'jp', gender: 'm', voiceIDs: [313, 330, 369, 379, 396]},
            {name: 'Korean Female', flag: 'kr', gender: 'f', voiceIDs: [54, 55, 56, 156, 183, 218, 306, 323, 362, 384, 57]},
            {name: 'Korean Male', flag: 'kr', gender: 'm', voiceIDs: [397]},
            {name: 'Latin Female', flag: 'va', gender: 'f', voiceIDs: [114], deprecated:true},   //DEPRECATED - NO LONGER SUPPORTED
            {name: 'Latin Male', flag: 'va', gender: 'm', voiceIDs: [165]},	
            {name: 'Norwegian Female', flag: 'no', gender: 'f', voiceIDs: [72, 73, 221,74]},
            {name: 'Norwegian Male', flag: 'no', gender: 'm', voiceIDs: [166]},	
            {name: 'Polish Female', flag: 'pl', gender: 'f', voiceIDs: [244,120,119,121,185,222,267,296,352,122]},
            {name: 'Polish Male', flag: 'pl', gender: 'm', voiceIDs: [314, 331, 370, 398]},
            {name: 'Portuguese Female', flag: 'br', gender: 'f', voiceIDs: [128,127,129,187,224,272,301,357,130]},
            {name: 'Portuguese Male', flag: 'br', gender: 'm', voiceIDs: [400]},
            {name: 'Romanian Female', flag: 'ro', gender: 'f', voiceIDs: [151, 150, 152, 225,46]},
            {name: 'Russian Female', flag: 'ru', gender: 'f', voiceIDs: [246,47,48,83,188,226,260,289,345,49]},
            {name: 'Russian Male', flag: 'ru', gender: 'm', voiceIDs: [316,333,372,387]},
            {name: 'Slovak Female', flag: 'sk', gender: 'f', voiceIDs: [133,132,134,227,135]},
            {name: 'Slovak Male', flag: 'sk', gender: 'm', voiceIDs: [167], deprecated:true},   //DEPRECATED - NO LONGER SUPPORTED	
            {name: 'Spanish Female', flag: 'es', gender: 'f', voiceIDs: [19, 238, 16, 17, 18, 20, 76, 174, 207,263,292,348,264,293,349,15]},
            {name: 'Spanish Male', flag: 'es', gender: 'm', voiceIDs: [309, 326, 365, 401]},
            {name: 'Spanish Latin American Female', flag: 'es', gender: 'f', voiceIDs: [239,137,136,138,175,208,265,294,350,139]},
            {name: 'Spanish Latin American Male', flag: 'es', gender: 'm', voiceIDs: [136, 310, 327, 366, 402]},
            {name: 'Swedish Female', flag: 'sv', gender: 'f', voiceIDs: [85, 149, 228, 65]},
            {name: 'Swedish Male', flag: 'sv', gender: 'm', voiceIDs: [148, 168]},
            {name: 'Tamil Male', flag: 'hi', gender: 'm', voiceIDs: [141]},
            {name: 'Thai Female', flag: 'th', gender: 'f', voiceIDs: [143,142,144,189,229,145]},
            {name: 'Thai Male', flag: 'th', gender: 'm', voiceIDs: [403]},
            {name: 'Turkish Female', flag: 'tr', gender: 'f', voiceIDs: [69, 70, 82, 190, 230,71]},
            {name: 'Turkish Male', flag: 'tr', gender: 'm', voiceIDs: [404]},
            {name: 'Vietnamese Female', flag: 'vi', gender: 'f', voiceIDs: [405]},
            {name: 'Vietnamese Male', flag: 'vi', gender: 'm', voiceIDs: [146]},
            {name: 'Afrikaans Male', flag: 'af', gender: 'm', voiceIDs: [93]},
            {name: 'Albanian Male', flag: 'sq', gender: 'm', voiceIDs: [94]},
            {name: 'Bosnian Male', flag: 'bs', gender: 'm', voiceIDs: [14]},
            {name: 'Catalan Male', flag: 'catalonia', gender: 'm', voiceIDs: [68]},
            {name: 'Croatian Male', flag: 'hr', gender: 'm', voiceIDs: [13]},
            {name: 'Esperanto Male', flag: 'eo', gender: 'm', voiceIDs: [108]},
            {name: 'Icelandic Male', flag: 'is', gender: 'm', voiceIDs: [110]},
            {name: 'Latvian Male', flag: 'lv', gender: 'm', voiceIDs: [115]},
            {name: 'Macedonian Male', flag: 'mk', gender: 'm', voiceIDs: [116]},
            {name: 'Moldavian Female', flag: 'md', gender: 'f', voiceIDs: [117]},
            {name: 'Moldavian Male', flag: 'md', gender: 'm', voiceIDs: [117], deprecated:true},   //DEPRECATED - NO LONGER SUPPORTED
            {name: 'Montenegrin Male', flag: 'me', gender: 'm', voiceIDs: [118]},
            {name: 'Serbian Male', flag: 'sr', gender: 'm', voiceIDs: [12]},
            {name: 'Serbo-Croatian Male', flag: 'hr', gender: 'm', voiceIDs: [131]},
            {name: 'Swahili Male', flag: 'sw', gender: 'm', voiceIDs: [140]},
            {name: 'Welsh Male', flag: 'cy', gender: 'm', voiceIDs: [147]},
            {name: 'Fallback UK Female', flag: 'gb', gender: 'f', voiceIDs: [8]}

        ];

        //All voices available on every system and device
        self.voicecollection = [
            {name: 'Google UK English Male'}, //0 male uk android/chrome
            {name: 'Agnes'}, //1 female us safari mac
            {name: 'Daniel Compact'}, //2 male us safari mac

            {name: 'Google UK English Female'}, //3 female uk android/chrome
            {name: 'en-GB', rate: 0.25, pitch: 1}, //4 male uk IOS
            {name: 'en-AU', rate: 0.25, pitch: 1}, //5 female english IOS
            
            {name: 'inglés Reino Unido'}, //6 spanish english android
            {name: 'English United Kingdom'}, //7 english english android
            {name: 'Fallback en-GB Female', lang: 'en-GB', fallbackvoice: true, service: 'g1', gender: 'female'}, //8 fallback english female
            
            {name: 'Eszter Compact'}, //9 Hungarian mac 
            {name: 'hu-HU', rate: 0.4}, //10 Hungarian iOS
            {name: 'Fallback Hungarian Female', lang: 'hu', fallbackvoice: true, service: 'g2'}, //11 Hungarian Female fallback

            {name: 'Fallback Serbian Male', lang: 'sr', fallbackvoice: true, service: 'g1', gender: 'male'}, //12 Serbian Male fallback

            {name: 'Fallback Croatian Male', lang: 'hr', fallbackvoice: true, service: 'g1', gender: 'male'}, //13 Croatian Male fallback		

            {name: 'Fallback Bosnian Male', lang: 'bs', fallbackvoice: true, service: 'g1', gender: 'male'}, //14 Bosnian Male fallback	

            {name: 'Fallback Spanish Female', lang: 'es', fallbackvoice: true, service: 'g1', gender: 'female'}, //15 Spanish Female fallback						
            {name: 'Spanish Spain'}, //16 female es android/chrome		
            {name: 'español España'}, //17 female es android/chrome	
            {name: 'Diego Compact', rate: 0.3}, //18 male es mac
            {name: 'Google Español'}, //19 male es chrome				
            {name: 'es-ES', rate: 0.20}, //20 male es iOS

            {name: 'Google Français'}, //21 FR chrome				
            {name: 'French France'}, //22 android/chrome		
            {name: 'francés Francia'}, //23 android/chrome	
            {name: 'Virginie Compact', rate: 0.5}, //24 mac
            {name: 'fr-FR', rate: 0.25}, //25 iOS		
            {name: 'Fallback French Female', lang: 'fr', fallbackvoice: true, service: 'g1', gender: 'female'}, //26 fallback								

            {name: 'Google Deutsch'}, //27 DE chrome				
            {name: 'German Germany'}, //28 android/chrome		
            {name: 'alemán Alemania'}, //29 android/chrome	
            {name: 'Yannick Compact', rate: 0.5}, //30 mac
            {name: 'de-DE', rate: 0.25}, //31 iOS		
            {name: 'Fallback Deutsch Female', lang: 'de', fallbackvoice: true, service: 'g1', gender: 'female'}, //32 fallback			

            {name: 'Google Italiano'}, //33 IT chrome				
            {name: 'Italian Italy'}, //34 android/chrome		
            {name: 'italiano Italia'}, //35 android/chrome	
            {name: 'Paolo Compact', rate: 0.5}, //36 mac
            {name: 'it-IT', rate: 0.25}, //37 iOS		
            {name: 'Fallback Italian Female', lang: 'it', fallbackvoice: true, service: 'g1', gender: 'female'}, //38 fallback								

            {name: 'Google US English', timerSpeed:1}, //39 EN chrome US English Female				
            {name: 'English United States'}, //40 android/chrome US English Female		
            {name: 'inglés Estados Unidos'}, //41 android/chrome US English Female	
            {name: 'Vicki'}, //42 mac US English Female
            {name: 'en-US', rate: 0.2, pitch: 1, timerSpeed:1.3}, //43 iOS US English Female	
            {name: 'Fallback US English', lang: 'en-US', fallbackvoice: true, timerSpeed:0, service: 'g1', gender: 'female'}, //44 fallback										
            {name: 'Fallback Dutch Female', lang: 'nl', fallbackvoice: true, timerSpeed:0, service: 'g1', gender: 'female'}, //45 fallback

            {name: 'Fallback Romanian', lang: 'ro', fallbackvoice: true, service: 'g1', gender: 'female'}, //46 Romanian Female fallback	

            {name: 'Milena Compact'}, //47 Russian mac 
            {name: 'ru-RU', rate: 0.25}, //48 iOS		
            {name: 'Fallback Russian', lang: 'ru', fallbackvoice: true, service: 'g1', gender: 'female'}, //49 Russian fallback	

            {name: 'Google 日本人', timerSpeed:1}, //50 Japanese Female Chrome 
            {name: 'Kyoko Compact'}, //51 Japanese Female mac 
            {name: 'ja-JP', rate: 0.25}, //52 iOS Japanese Female	
            {name: 'Fallback Japanese Female', lang: 'ja', fallbackvoice: true, service: 'g1', gender: 'female'}, //53 Japanese Female fallback	

            {name: 'Google 한국의', timerSpeed:1}, //54 KO Chrome 
            {name: 'Narae Compact'}, //55 Korean mac 
            {name: 'ko-KR', rate: 0.25}, //56 iOS		
            {name: 'Fallback Korean Female', lang: 'ko', fallbackvoice: true, service: 'g1', gender: 'female'}, //57 Korean fallback	

            {name: 'Google 中国的', timerSpeed:1}, //58 CN Chrome 
            {name: 'Ting-Ting Compact'}, //59 Chinese mac Female
            {name: 'zh-CN', rate: 0.25}, //60 iOS		
            {name: 'Fallback Chinese', lang: 'zh-CN', fallbackvoice: true, service: 'g1', gender: 'female'}, //61 Chinese Female fallback	

            {name: 'Alexandros Compact'}, //62 Greek Male Mac 
            {name: 'el-GR', rate: 0.25}, //63 iOS		
            {name: 'Fallback Greek', lang: 'el', fallbackvoice: true, service: 'g2', gender: 'female'}, //64 Greek Female fallback	

            {name: 'Fallback Swedish', lang: 'sv', fallbackvoice: true, service: 'g2', gender: 'female'}, //65 Swedish Female fallback	

            {name: 'hi-IN', rate: 0.25}, //66 iOS		
            {name: 'Fallback Hindi Female', lang: 'hi', fallbackvoice: true, service: 'g1', gender: 'female'}, //67 Hindi Female fallback	

            {name: 'Fallback Catalan', lang: 'ca', fallbackvoice: true, service: 'g1', gender: 'male'}, //68 Catalan Male fallback	

            {name: 'Aylin Compact'}, //69 Turkish Female Mac 
            {name: 'tr-TR', rate: 0.25}, //70 iOS Turkish Female	
            {name: 'Fallback Turkish', lang: 'tr', fallbackvoice: true, service: 'g1', gender: 'female'}, //71 Turkish Female fallback	

            {name: 'Stine Compact'}, //72 Norweigan Male Mac 

            {name: 'no-NO', rate: 0.25}, //73 iOS Female		
            {name: 'Fallback Norwegian', lang: 'no', fallbackvoice: true, service: 'g1', gender: 'female'}, //74 Norwegian Female fallback
            
            {name: 'Daniel'}, //75 English UK male uk safari 8 mac	
            {name: 'Monica'}, //76 Spanish female es safari 8 mac
            {name: 'Amelie'}, //77 French Canadian female fr safari 8 mac
            {name: 'Anna'}, //78 female de safari 8 mac
            {name: 'Alice'}, //79 Italian female it safari 8 mac
            {name: 'Melina'}, //80 Greek female gr safari 8 mac
            {name: 'Mariska'}, //81 Hungarian female hu safari 8 mac
            {name: 'Yelda'}, //82 Turkish female tr safari 8 mac
            {name: 'Milena'}, //83 Russian female ru safari 8 mac

            //Gender Disparity
            {name: 'Xander'}, //84 Dutch female nl safari 8 mac
            {name: 'Alva'},  //85 Swedish female sv safari 8 mac

            // Gender Disparity
            {name: 'Lee Compact'}, //86 Australian Male Mac 
            {name: 'Karen'}, //87 Australian Female safari 8 mac 
            {name: 'Fallback Australian Female', lang: 'en-AU', fallbackvoice: true, service: 'g1', gender: 'female'}, //88 Australian Female fallback	

            // Gender Disparity
            {name: 'Mikko Compact'}, //89 Finnish Male Mac 
            {name: 'Satu'}, //90 Finnish Female safari 8 mac 
            {name: 'fi-FI', rate: 0.25}, //91 iOS		
            {name: 'Fallback Finnish', lang: 'fi', fallbackvoice: true, service: 'g1', gender: 'female'}, //92 Finnish Female fallback	

            {name: 'Fallback Afrikans', lang: 'af', fallbackvoice: true, service: 'g1', gender: 'male'}, //93 Afrikans Male fallback	
 
            {name: 'Fallback Albanian', lang: 'sq', fallbackvoice: true, service: 'g1', gender: 'male'}, //94 Albanian Male fallback	

            {name: 'Maged Compact'}, //95 Arabic Male Mac 
            {name: 'Tarik'}, //96 Arabic Male safari 8 mac 
            {name: 'ar-SA', rate: 0.25}, //97 iOS	
            {name: 'Fallback Arabic', lang: 'ar', fallbackvoice: true, service: 'g1', gender: 'female'}, //98 Arabic Female fallback	

            {name: 'Fallback Armenian', lang: 'hy', fallbackvoice: true, service: 'g1', gender: 'male'}, //99 Armenian Male fallback	

            {name: 'Zuzana Compact'}, //100 Czech Female Mac 
            {name: 'Zuzana'}, //101 Czech Female safari 8 mac 
            {name: 'cs-CZ', rate: 0.25}, //102 iOS	
            {name: 'Fallback Czech', lang: 'cs', fallbackvoice: true, service: 'g1', gender: 'female'}, //103 Czech Female fallback	

            {name: 'Ida Compact'}, //104 Danish Female Mac 
            {name: 'Sara'}, //105 Danish Female safari 8 mac 
            {name: 'da-DK', rate: 0.25}, //106 iOS	
            {name: 'Fallback Danish', lang: 'da', fallbackvoice: true, service: 'g1', gender: 'female'}, //107 Danish Female fallback	

            {name: 'Fallback Esperanto', lang: 'eo', fallbackvoice: true, service: 'g1', gender: 'male'}, //108 Esperanto Male fallback	
 
            {name: 'Fallback Haitian Creole', lang: 'ht', fallbackvoice: true}, //109 Haitian Creole Female fallback NO LONGER SUPPORTED

            {name: 'Fallback Icelandic', lang: 'is', fallbackvoice: true, service: 'g1', gender: 'male'}, //110 Icelandic Male fallback	

            {name: 'Damayanti'}, //111 Indonesian Female safari 8 mac 
            {name: 'id-ID', rate: 0.25}, //112 iOS		
            {name: 'Fallback Indonesian Female', lang: 'id', fallbackvoice: true, service: 'g1', gender: 'female'}, //113 Indonesian Female fallback	

            {name: 'Fallback Latin Female', lang: 'la', fallbackvoice: true, service: 'g2', gender: 'female'}, //114 Latin Female fallback	
            {name: 'Fallback Latvian Male', lang: 'lv', fallbackvoice: true, service: 'g1', gender: 'male'}, //115 Latvian Male fallback	
            {name: 'Fallback Macedonian Male', lang: 'mk', fallbackvoice: true, service: 'g1', gender: 'male'}, //116 Macedonian Male fallback	
            {name: 'Fallback Moldavian Female', lang: 'mo', fallbackvoice: true, service: 'g2', gender: 'female'}, //117 Moldavian Female fallback	
            {name: 'Fallback Montenegrin Male', lang: 'sr-ME', fallbackvoice: true, service: 'g1', gender: 'male'}, //118 Montenegrin Male fallback	

            {name: 'Agata Compact'}, //119 Polish Female Mac 
            {name: 'Zosia'}, //120 Polish Female safari 8 mac 
            {name: 'pl-PL', rate: 0.25}, //121 iOS		
            {name: 'Fallback Polish Female', lang: 'pl', fallbackvoice: true, service: 'g1', gender: 'female'}, //122 Polish Female fallback	

            {name: 'Raquel Compact'}, //123 Brazilian Portugese Female Male Mac 
            {name: 'Luciana'}, //124 Brazilian Portugese Female safari 8 mac 
            {name: 'pt-BR', rate: 0.25}, //125 iOS		
            {name: 'Fallback Brazilian Portuguese Female', lang: 'pt-BR', fallbackvoice: true, service: 'g1', gender: 'female'}, //126 Brazilian Portugese Female fallback	

            {name: 'Joana Compact'}, //127 Portuguese Female Mac 
            {name: 'Joana'}, //128 Portuguese Female safari 8 mac 
            {name: 'pt-PT', rate: 0.25}, //129 iOS		
            {name: 'Fallback Portuguese', lang: 'pt-PT', fallbackvoice: true, service: 'g1', gender: 'female'}, //130 Portuguese Female fallback	

            {name: 'Fallback Serbo-Croation', lang: 'sh', fallbackvoice: true, service: 'g1', gender: 'male'}, //131 Serbo-Croation Male fallback	

            {name: 'Laura Compact'}, //132 Slovak Female Mac 
            {name: 'Laura'}, //133 Slovak Female safari 8 mac 
            {name: 'sk-SK', rate: 0.25}, //134 iOS		
            {name: 'Fallback Slovak', lang: 'sk', fallbackvoice: true, service: 'g1', gender: 'female'}, //135 Slovak Female fallback	

            //Gender Disparity
            {name: 'Javier Compact'}, //136 Spanish (Latin American) Male Mac 
            {name: 'Paulina'}, //137 Spanish Mexican Female safari 8 mac 
            {name: 'es-MX', rate: 0.25}, //138 iOS		
            {name: 'Fallback Spanish (Latin American) Female', lang: 'es-419', fallbackvoice: true, service: 'g1', gender: 'female'}, //139 Spanish (Latin American) Female fallback	

            {name: 'Fallback Swahili', lang: 'sw', fallbackvoice: true, service: 'g1', gender: 'male'}, //140 Swahili Male fallback	

            {name: 'Fallback Tamil', lang: 'ta', fallbackvoice: true, service: 'g1', gender: 'male'}, //141 Tamil Male fallback	

            {name: 'Narisa Compact'}, //142 Thai Female Mac 
            {name: 'Kanya'}, //143 Thai Female safari 8 mac 
            {name: 'th-TH', rate: 0.25}, //144 iOS		
            {name: 'Fallback Thai Female', lang: 'th', fallbackvoice: true, service: 'g1', gender: 'female'}, //145 Thai Female fallback	

            {name: 'Fallback Vietnamese Male', lang: 'vi', fallbackvoice: true, service: 'g1', gender: 'male'}, //146 Vietnamese Male fallback	

            {name: 'Fallback Welsh', lang: 'cy', fallbackvoice: true, service: 'g1', gender: 'male'}, //147 Welsh Male fallback

            // Gender Disparity
            {name: 'Oskar Compact'}, //148 Swedish Male Mac 
            {name: 'sv-SE', rate: 0.25}, //149 iOS	

            // Gender Disparity
            {name: 'Simona Compact'}, //150 Romanian mac female
            {name: 'Ioana'}, //151 Romanian Female safari 8 mac
            {name: 'ro-RO', rate: 0.25}, //152 iOS female

            {name: 'Kyoko'}, //153 Japanese Female safari 8 mac 

            {name: 'Lekha'}, //154 Hindi Female safari 8 mac 

            {name: 'Ting-Ting'}, //155 Chinese Female safari 8 mac 

            {name: 'Yuna'}, //156 Korean Female safari 8 mac 

            // Gender Disparity
            {name: 'Xander Compact'}, //157 Dutch male or female nl safari 8 mac
            {name: 'nl-NL', rate: 0.25}, //158 iOS		

            {name: 'Fallback UK English Male', lang: 'en-GB', fallbackvoice: true, service: 'g1', voicename: 'rjs', gender: 'male'}, //159 UK Male fallback	

            {name: 'Finnish Male', lang: 'fi', fallbackvoice: true, service: 'g1', voicename: '', gender: 'male'}, //160 Finnish Male fallback	

            {name: 'Czech Male', lang: 'cs', fallbackvoice: true, service: 'g1', voicename: '', gender: 'male'}, //161 Czech Male fallback	

            {name: 'Danish Male', lang: 'da', fallbackvoice: true, service: 'g1', voicename: '', gender: 'male'}, //162 Danish Male fallback	

            {name: 'Greek Male', lang: 'el', fallbackvoice: true, service: 'g1', voicename: '', gender: 'male'}, //163 Greek Male fallback	

            {name: 'Hungarian Male', lang: 'hu', fallbackvoice: true, service: 'g1', voicename: '', gender: 'male'}, //164 Hungarian Male fallback	

            {name: 'Latin Male', lang: 'la', fallbackvoice: true, service: 'g2', voicename: '', gender: 'male'}, //165 Latin Male fallback	

            {name: 'Norwegian Male', lang: 'no', fallbackvoice: true, service: 'g1', voicename: '', gender: 'male'}, //166 Norwegian Male fallback	

            {name: 'Slovak Male', lang: 'sk', fallbackvoice: true, service: 'g1', voicename: '', gender: 'male'}, //167 Slovak Male fallback	

            {name: 'Swedish Male', lang: 'sv', fallbackvoice: true, service: 'g1', voicename: '', gender: 'male'}, //168 Swedish Male fallback
	
            {name: 'Fallback US English Male', lang: 'en-US', fallbackvoice: true, service: 'g1', voicename: '', gender: 'male'}, //169 US English Male fallback

            {name: 'German Germany', lang: 'de_DE'}, //170 Android 5 German Female
            {name: 'English United Kingdom', lang: 'en_GB'}, //171 Android 5 English United Kingdom Female
            {name: 'English India', lang: 'en_IN'}, //172 Android 5 English India Female
            {name: 'English United States', lang: 'en_US'}, //173 Android 5 English United States Female
            {name: 'Spanish Spain', lang: 'es_ES'}, //174 Android 5 Spanish Female
            {name: 'Spanish Mexico', lang: 'es_MX'}, //175 Android 5 Spanish Mexico Female
            {name: 'Spanish United States', lang: 'es_US'}, //176 Android 5 Spanish Mexico Female
            {name: 'French Belgium', lang: 'fr_BE'}, //177 Android 5 French Belgium Female
            {name: 'French France', lang: 'fr_FR'}, //178 Android 5 French France Female
            {name: 'Hindi India', lang: 'hi_IN'}, //179 Android 5 Hindi India Female
            {name: 'Indonesian Indonesia', lang: 'in_ID'}, //180 Android 5 Indonesian Female
            {name: 'Italian Italy', lang: 'it_IT'}, //181 Android 5 Italian Female
            {name: 'Japanese Japan', lang: 'ja_JP'}, //182 Android 5 Japanese Female
            {name: 'Korean South Korea', lang: 'ko_KR'}, //183 Android 5 Korean Female
            {name: 'Dutch Netherlands', lang: 'nl_NL'}, //184 Android 5 Dutch Female
            {name: 'Polish Poland', lang: 'pl_PL'}, //185 Android 5 Polish Female
            {name: 'Portuguese Brazil', lang: 'pt_BR'}, //186 Android 5 Portuguese Brazil Female
            {name: 'Portuguese Portugal', lang: 'pt_PT'}, //187 Android 5 Portuguese Portugal Female
            {name: 'Russian Russia', lang: 'ru_RU'}, //188 Android 5 Russian Female
            {name: 'Thai Thailand', lang: 'th_TH'}, //189 Android 5 Thai Female
            {name: 'Turkish Turkey', lang: 'tr_TR'}, //190 Android 5 Turkish Female
            {name: 'Chinese China', lang: 'zh_CN_#Hans'}, //191 Android 5 Chinese China Female
            {name: 'Chinese Hong Kong', lang: 'zh_HK_#Hans'}, //192 Android 5 Chinese Hong Kong Simplified Female
            {name: 'Chinese Hong Kong', lang: 'zh_HK_#Hant'}, //193 Android 5 Chinese Hong Kong Traditional Female
            {name: 'Chinese Taiwan', lang: 'zh_TW_#Hant'}, //194 Android 5 Chinese Taiwan Female

            {name: 'Alex'}, //195 US English Male safari 8 mac

            {name: 'Maged', lang: 'ar-SA'}, //196 iOS 9 Arabic Male
            {name: 'Zuzana', lang: 'cs-CZ'}, //197 iOS 9 Czech Female
            {name: 'Sara', lang: 'da-DK'}, //198 iOS 9 Danish Female
            {name: 'Anna', lang: 'de-DE'}, //199 iOS 9 Deutsch Female
            {name: 'Melina', lang: 'el-GR'}, //200 iOS 9 Greek Female
            {name: 'Karen', lang: 'en-AU'}, //201 iOS 9 English (AU) Female
            {name: 'Daniel', lang: 'en-GB'}, //202 iOS 9 English (GB) Male
            {name: 'Moira', lang: 'en-IE'}, //203 iOS 9 English (IE) Female
            {name: 'Samantha (Enhanced)', lang: 'en-US'}, //204 iOS 9 US English Female
            {name: 'Samantha', lang: 'en-US'}, //205 iOS 9 US English Female
            {name: 'Tessa', lang: 'en-ZA'}, //206 iOS 9 English Female
            {name: 'Monica', lang: 'es-ES'}, //207 iOS 9 Spanish Female
            {name: 'Paulina', lang: 'es-MX'}, //208 iOS 9 Spanish Latin American Female
            {name: 'Satu', lang: 'fi-FI'}, //209 iOS 9 Finnish Female
            {name: 'Amelie', lang: 'fr-CA'}, //210 iOS 9 French (CA) Female
            {name: 'Thomas', lang: 'fr-FR'}, //211 iOS 9 French (FR) Male
            {name: 'Carmit', lang: 'he-IL'}, //212 iOS 9 Hebrew Female
            {name: 'Lekha', lang: 'hi-IN'}, //213 iOS 9 Hindi Female
            {name: 'Mariska', lang: 'hu-HU'}, //214 iOS 9 Hungarian Female
            {name: 'Damayanti', lang: 'id-ID'}, //215 iOS 9 Indonesian Female
            {name: 'Alice', lang: 'it-IT'}, //216 iOS 9 Italian Female
            {name: 'Kyoko', lang: 'ja-JP'}, //217 iOS 9 Japanese Female
            {name: 'Yuna', lang: 'ko-KR'}, //218 iOS 9 Korean Female
            {name: 'Ellen', lang: 'nl-BE'}, //219 iOS 9 Dutch Female
            {name: 'Xander', lang: 'nl-NL'}, //220 iOS 9 Dutch Male
            {name: 'Nora', lang: 'no-NO'}, //221 iOS 9 Norwegian Female
            {name: 'Zosia', lang: 'pl-PL'}, //222 iOS 9 Polish Female
            {name: 'Luciana', lang: 'pt-BR'}, //223 iOS 9 Portuguese (BR) Female
            {name: 'Joana', lang: 'pt-PT'}, //224 iOS 9 Portuguese (PT) Female
            {name: 'Ioana', lang: 'ro-RO'}, //225 iOS 9 Romanian Female
            {name: 'Milena', lang: 'ru-RU'}, //226 iOS 9 Russian Female
            {name: 'Laura', lang: 'sk-SK'}, //227 iOS 9 Slovak Female
            {name: 'Alva', lang: 'sv-SE'}, //228 iOS 9 Swedish Female
            {name: 'Kanya', lang: 'th-TH'}, //229 iOS 9 Thai Female
            {name: 'Yelda', lang: 'tr-TR'}, //230 iOS 9 Turkish Female
            {name: 'Ting-Ting', lang: 'zh-CN'}, //231 iOS 9 Chinese (PRC) Female
            {name: 'Sin-Ji', lang: 'zh-HK'}, //232 iOS 9 Chinese (Hong Kong SAR) Female
            {name: 'Mei-Jia', lang: 'zh-TW'}, //233 iOS 9 Chinese (Taiwan) Female

            // Microsoft Edge 14
            {name: 'Microsoft David Mobile - English (United States)', lang: 'en-US'}, //234 Microsoft Edge David English Male
            {name: 'Microsoft Zira Mobile - English (United States)', lang: 'en-US'}, //235 Microsoft Edge Zira English Female
            {name: 'Microsoft Mark Mobile - English (United States)', lang: 'en-US'}, //236 Microsoft Edge Mark English Male

            {name: 'native', lang: ''}, //237 Chromium Windows native US Male

            {name: 'Google español'}, //238 Google Chrome Windows newer name variants Spanish Female
            {name: 'Google español de Estados Unidos'}, //239 Google Chrome Windows newer name variants US Spanish Female
            {name: 'Google français'}, //240 Google Chrome Windows newer name variants French Female
            {name: 'Google Bahasa Indonesia'}, //241 Google Chrome Windows newer name variants Indonesian Female
            {name: 'Google italiano'}, //242 Google Chrome Windows newer name variants Italian Female
            {name: 'Google Nederlands'}, //243 Google Chrome Windows newer name variants Dutch Female
            {name: 'Google polski'}, //244 Google Chrome Windows newer name variants Polish Female
            {name: 'Google português do Brasil'}, //245 Google Chrome Windows newer name variants Brazilian Portugese Female
            {name: 'Google русский'}, //246 Google Chrome Windows newer name variants Russian Female
            {name: 'Google हिन्दी'}, //247 Google Chrome Windows newer name variants Hindi Female
            {name: 'Google 日本語'}, //248 Google Chrome Windows newer name variants Japanese Female
            {name: 'Google 普通话（中国大陆）'}, //249 Google Chrome Windows newer name variants Chinese Female

            {name: 'Google 粤語（香港）'}, //250 Google Chrome Windows newer name variants Hong Kong Chinese Female
            {name: 'zh-HK', rate: 0.25}, //251 iOS           
            {name: 'Fallback Chinese (Hong Kong) Female', lang: 'zh-HK', fallbackvoice: true, service: 'g1', gender: 'female'}, //252 Chinese (Hong Kong) Female fallback     

            {name: 'Google 粤語（香港）'}, //253 Google Chrome Windows newer name variants Chinese Taiwan Female
            {name: 'zh-TW', rate: 0.25}, //254 iOS           
            {name: 'Fallback Chinese (Taiwan) Female', lang: 'zh-TW', fallbackvoice: true, service: 'g1', gender: 'female'}, //255 Chinese Taiwan Female fallback

            {name: 'Microsoft George Mobile - English (United Kingdom)', lang: 'en-GB'}, //256 Male
            {name: 'Microsoft Susan Mobile - English (United Kingdom)', lang: 'en-GB'}, //257 Female
            {name: 'Microsoft Hazel Mobile - English (United Kingdom)', lang: 'en-GB'}, //258 Female
            {name: 'Microsoft Heera Mobile - English (India)', lang: 'en-In'}, //259 Female
            {name: 'Microsoft Irina Mobile - Russian (Russia)', lang: 'ru-RU'}, //260 Female
            {name: 'Microsoft Hedda Mobile - German (Germany)', lang: 'de-DE'}, //261 Female
            {name: 'Microsoft Katja Mobile - German (Germany)', lang: 'de-DE'}, //262
            {name: 'Microsoft Helena Mobile - Spanish (Spain)', lang: 'es-ES'}, //263 Female
            {name: 'Microsoft Laura Mobile - Spanish (Spain)', lang: 'es-ES'}, //264 Female
            {name: 'Microsoft Sabina Mobile - Spanish (Mexico)', lang: 'es-MX'}, //265 Female
            {name: 'Microsoft Julie Mobile - French (France)', lang: 'fr-FR'}, //266 Female
            {name: 'Microsoft Paulina Mobile - Polish (Poland)', lang: 'pl-PL'}, //267 Female
            {name: 'Microsoft Huihui Mobile - Chinese (Simplified, PRC)', lang: 'zh-CN'}, //268 Female
            {name: 'Microsoft Yaoyao Mobile - Chinese (Simplified, PRC)', lang: 'zh-CN'}, //269 Female
            {name: 'Microsoft Tracy Mobile - Chinese (Traditional, Hong Kong S.A.R.)', lang: 'zh-CN'}, //270 Female
            {name: 'Microsoft Elsa Mobile - Italian (Italy)', lang: 'it-IT'}, //271 Female
            {name: 'Microsoft Maria Mobile - Portuguese (Brazil)', lang: 'pt-BR'}, //272 Female
            {name: 'Microsoft Ayumi Mobile - Japanese (Japan)', lang: 'ja-JP'}, //273
            {name: 'Microsoft Haruka Mobile - Japanese (Japan)', lang: 'ja-JP'}, //274 Female

            {name: 'Helena', lang: 'de-DE'}, //275 iOS 10 siri Deutsch Female
            {name: 'Catherine', lang: 'en-AU'}, //276 iOS 10 siri Australian Female
            {name: 'Arthur', lang: 'en-GB'}, //277 iOS 10 siri UK English Male
            {name: 'Martha', lang: 'en-GB'}, //278 iOS 10 siri UK English Female
            {name: 'Marie', lang: 'fr-FR'}, //279 iOS 10 siri French Female
            {name: 'O-ren', lang: 'ja-JP'}, //280 iOS 10 siri Japanese Female
            {name: 'Yu-shu', lang: 'zh-CN'}, //281 iOS 10 siri Chinese Female

            // Microsoft Edge 41.16275.1000.0
            {name: 'Microsoft David - English (United States)', lang: 'en-US'}, //282 like 234 Microsoft Edge David English Male
            {name: 'Microsoft Zira - English (United States)', lang: 'en-US'}, //283 like 235 Microsoft Edge Zira English Female
            {name: 'Microsoft Mark - English (United States)', lang: 'en-US'}, //284 like 236 Microsoft Edge Mark English Male
            {name: 'Microsoft George - English (United Kingdom)', lang: 'en-GB'}, //285 like 256 Male
            {name: 'Microsoft Susan - English (United Kingdom)', lang: 'en-GB'}, //286 like 257 Female
            {name: 'Microsoft Hazel - English (United Kingdom)', lang: 'en-GB'}, //287 like 258 Female
            {name: 'Microsoft Heera - English (India)', lang: 'en-In'}, //288 like 259 Female
            {name: 'Microsoft Irina - Russian (Russia)', lang: 'ru-RU'}, //289 like 260 Female
            {name: 'Microsoft Hedda - German (Germany)', lang: 'de-DE'}, //290 like 261 Female
            {name: 'Microsoft Katja - German (Germany)', lang: 'de-DE'}, //291 like 262
            {name: 'Microsoft Helena - Spanish (Spain)', lang: 'es-ES'}, //292 like 263 Female
            {name: 'Microsoft Laura - Spanish (Spain)', lang: 'es-ES'}, //293 like 264 Female
            {name: 'Microsoft Sabina - Spanish (Mexico)', lang: 'es-MX'}, //294 like 265 Female
            {name: 'Microsoft Julie - French (France)', lang: 'fr-FR'}, //295 like 266 Female
            {name: 'Microsoft Paulina - Polish (Poland)', lang: 'pl-PL'}, //296 like 267 Female
            {name: 'Microsoft Huihui - Chinese (Simplified, PRC)', lang: 'zh-CN'}, //297 like 268 Female
            {name: 'Microsoft Yaoyao - Chinese (Simplified, PRC)', lang: 'zh-CN'}, //298 like 269 Female
            {name: 'Microsoft Tracy - Chinese (Traditional, Hong Kong S.A.R.)', lang: 'zh-CN'}, //299 like 270 Female
            {name: 'Microsoft Elsa - Italian (Italy)', lang: 'it-IT'}, //300 like 271 Female
            {name: 'Microsoft Maria - Portuguese (Brazil)', lang: 'pt-BR'}, //301 like 272 Female
            {name: 'Microsoft Ayumi - Japanese (Japan)', lang: 'ja-JP'}, //302 like 273
            {name: 'Microsoft Haruka - Japanese (Japan)', lang: 'ja-JP'}, //303 like 274 Female
            {name: 'Microsoft Hortense - French (France)', lang: 'fr-FR'}, //304 Female like 266
            {name: 'Microsoft Hanhan - Chinese (Traditional, Taiwan)', lang: 'zh-TW'}, //305 Female
            {name: 'Microsoft Heami - Korean (Korean)', lang: 'ko-KR'}, //306 like 218 Female
            {name: 'Microsoft Stefan - German (Germany)', lang: 'de-DE'}, //307 Male
            {name: 'Microsoft Ravi - English (India)', lang: 'en-IN'}, //308 Male ** NOT USED
            {name: 'Microsoft Pablo - Spanish (Spain)', lang: 'es-ES'}, //309 Male
            {name: 'Microsoft Raul - Spanish (Mexico)', lang: 'es-MX'}, //310 Male
            {name: 'Microsoft Paul - French (France)', lang: 'fr-FR'}, //311 Male
            {name: 'Microsoft Cosimo - Italian (Italy)', lang: 'it-IT'}, //312 Male
            {name: 'Microsoft Ichiro - Japanese (Japan)', lang: 'ja-JP'}, //313 Male
            {name: 'Microsoft Adam - Polish (Poland)', lang: 'pl-PL'}, //314 Male
            {name: 'Microsoft Daniel - Portuguese (Brazil)', lang: 'pt-BR'}, //315 Male
            {name: 'Microsoft Pavel - Russian (Russia)', lang: 'ru-RU'}, //316 Male
            {name: 'Microsoft Kangkang - Chinese (Simplified, PRC)', lang: 'zh-CN'}, //317 Male
            {name: 'Microsoft Danny - Chinese (Traditional, Hong Kong S.A.R.)', lang: 'zh-HK'}, //318 Male
            {name: 'Microsoft Yating - Chinese (Traditional, Taiwan)', lang: 'zh-TW'}, //319 Female
            {name: 'Microsoft Zhiwei - Chinese (Traditional, Taiwan)', lang: 'zh-TW'}, //320 Male
            // Microsoft new Mobile
            {name: 'Microsoft Hortense Mobile - French (France)', lang: 'fr-FR'}, //321 like 304 Female
            {name: 'Microsoft Hanhan Mobile - Chinese (Traditional, Taiwan)', lang: 'zh-TW'}, //322 like 305 Female
            {name: 'Microsoft Heami Mobile - Korean (Korean)', lang: 'ko-KR'}, //323 like 306 Female
            {name: 'Microsoft Stefan Mobile - German (Germany)', lang: 'de-DE'}, //324 like 307 Male
            {name: 'Microsoft Ravi Mobile - English (India)', lang: 'en-IN'}, //325 like 308 Male ** NOT USED
            {name: 'Microsoft Pablo Mobile - Spanish (Spain)', lang: 'es-ES'}, //326 like 309 Male
            {name: 'Microsoft Raul Mobile - Spanish (Mexico)', lang: 'es-MX'}, //327 like 310 Male
            {name: 'Microsoft Paul Mobile - French (France)', lang: 'fr-FR'}, //328 like 311 Male
            {name: 'Microsoft Cosimo Mobile - Italian (Italy)', lang: 'it-IT'}, //329 like 312 Male
            {name: 'Microsoft Ichiro Mobile - Japanese (Japan)', lang: 'ja-JP'}, //330 like 313 Male
            {name: 'Microsoft Adam Mobile - Polish (Poland)', lang: 'pl-PL'}, //331 like 314 Male
            {name: 'Microsoft Daniel Mobile - Portuguese (Brazil)', lang: 'pt-BR'}, //332 like 315 Male
            {name: 'Microsoft Pavel Mobile - Russian (Russia)', lang: 'ru-RU'}, //333 like 316 Male
            {name: 'Microsoft Kangkang Mobile - Chinese (Simplified, PRC)', lang: 'zh-CN'}, //334 like 317 Male
            {name: 'Microsoft Danny Mobile - Chinese (Traditional, Hong Kong S.A.R.)', lang: 'zh-HK'}, //335 like 318 Male
            {name: 'Microsoft Yating Mobile - Chinese (Traditional, Taiwan)', lang: 'zh-TW'}, //336 like 319 Female
            {name: 'Microsoft Zhiwei Mobile - Chinese (Traditional, Taiwan)', lang: 'zh-TW'}, //337 like 320 Male
            // Microsoft available in Chrome with Desktop string
            {name: 'Microsoft David Desktop - English (United States)', lang: 'en-US'}, //338 like 282, 234 Microsoft Edge David English Male
            {name: 'Microsoft Zira Desktop - English (United States)', lang: 'en-US'}, //339 like 283, 235 Microsoft Edge Zira English Female
            {name: 'Microsoft Mark Desktop - English (United States)', lang: 'en-US'}, //340 like 284, 236 Microsoft Edge Mark English Male
            {name: 'Microsoft George Desktop - English (United Kingdom)', lang: 'en-GB'}, //341 like 285, 256 Male
            {name: 'Microsoft Susan Desktop - English (United Kingdom)', lang: 'en-GB'}, //342 like 286, 257 Female
            {name: 'Microsoft Hazel Desktop - English (United Kingdom)', lang: 'en-GB'}, //343 like 287, 258 Female
            {name: 'Microsoft Heera Desktop - English (India)', lang: 'en-In'}, //344 like 288, 259 Female
            {name: 'Microsoft Irina Desktop - Russian (Russia)', lang: 'ru-RU'}, //345 like 289, 260 Female
            {name: 'Microsoft Hedda Desktop - German (Germany)', lang: 'de-DE'}, //346 like 290, 261 Female
            {name: 'Microsoft Katja Desktop - German (Germany)', lang: 'de-DE'}, //347 like 291, 262
            {name: 'Microsoft Helena Desktop - Spanish (Spain)', lang: 'es-ES'}, //348 like 292, 263 Female
            {name: 'Microsoft Laura Desktop - Spanish (Spain)', lang: 'es-ES'}, //349 like 293, 264 Female
            {name: 'Microsoft Sabina Desktop - Spanish (Mexico)', lang: 'es-MX'}, //350 like 294, 265 Female
            {name: 'Microsoft Julie Desktop - French (France)', lang: 'fr-FR'}, //351 like 295, 266 Female
            {name: 'Microsoft Paulina Desktop - Polish (Poland)', lang: 'pl-PL'}, //352 like 296, 267 Female
            {name: 'Microsoft Huihui Desktop - Chinese (Simplified, PRC)', lang: 'zh-CN'}, //353 like 297, 268 Female
            {name: 'Microsoft Yaoyao Desktop - Chinese (Simplified, PRC)', lang: 'zh-CN'}, //354 like 298, 269 Female
            {name: 'Microsoft Tracy Desktop - Chinese (Traditional, Hong Kong S.A.R.)', lang: 'zh-CN'}, //355 like 299, 270 Fenale
            {name: 'Microsoft Elsa Desktop - Italian (Italy)', lang: 'it-IT'}, //356 like 300, 271 Female
            {name: 'Microsoft Maria Desktop - Portuguese (Brazil)', lang: 'pt-BR'}, //357 like 301, 272 Female
            {name: 'Microsoft Ayumi Desktop - Japanese (Japan)', lang: 'ja-JP'}, //358 like 302, 273
            {name: 'Microsoft Haruka Desktop - Japanese (Japan)', lang: 'ja-JP'}, //359 like 303, 274 Female
            {name: 'Microsoft Hortense Desktop - French (France)', lang: 'fr-FR'}, //360 like 304 Female
            {name: 'Microsoft Hanhan Desktop - Chinese (Traditional, Taiwan)', lang: 'zh-TW'}, //361 like 322, 305 Female
            {name: 'Microsoft Heami Desktop - Korean (Korean)', lang: 'ko-KR'}, //362 like 323, 306 Female
            {name: 'Microsoft Stefan Desktop - German (Germany)', lang: 'de-DE'}, //363 like 324, 307 Male
            {name: 'Microsoft Ravi Desktop - English (India)', lang: 'en-IN'}, //364 like 325, 308 Male ** NOT USED
            {name: 'Microsoft Pablo Desktop - Spanish (Spain)', lang: 'es-ES'}, //365 like 326, 309 Male
            {name: 'Microsoft Raul Desktop - Spanish (Mexico)', lang: 'es-MX'}, //366 like 327, 310 Male
            {name: 'Microsoft Paul Desktop - French (France)', lang: 'fr-FR'}, //367 like 328, 311 Male
            {name: 'Microsoft Cosimo Desktop - Italian (Italy)', lang: 'it-IT'}, //368 like 239, 312 Male
            {name: 'Microsoft Ichiro Desktop - Japanese (Japan)', lang: 'ja-JP'}, //369 like 330, 313 Male
            {name: 'Microsoft Adam Desktop - Polish (Poland)', lang: 'pl-PL'}, //370 like 331, 314 Male
            {name: 'Microsoft Daniel Desktop - Portuguese (Brazil)', lang: 'pt-BR'}, //371 like 332, 315 Male
            {name: 'Microsoft Pavel Desktop - Russian (Russia)', lang: 'ru-RU'}, //372 like 333, 316 Male
            {name: 'Microsoft Kangkang Desktop - Chinese (Simplified, PRC)', lang: 'zh-CN'}, //373 like 334, 317 Male
            {name: 'Microsoft Danny Desktop - Chinese (Traditional, Hong Kong S.A.R.)', lang: 'zh-HK'}, //374 like 335, 318 Male
            {name: 'Microsoft Yating Desktop - Chinese (Traditional, Taiwan)', lang: 'zh-TW'}, //375 like 336, 319 Female
            {name: 'Microsoft Zhiwei Desktop - Chinese (Traditional, Taiwan)', lang: 'zh-TW'}, //376 like 337, 320 Male

            {name: 'Martin', lang: 'de-DE'}, //377 iOS 11 siri Deutsch Male
            {name: 'Daniel', lang: 'fr-FR'}, //378 iOS 11 siri French Male
            {name: 'Hattori', lang: 'ja-JP'}, //379 iOS 11 siri Japanese Male
            {name: 'Li-mu', lang: 'zh-CN'}, //380 iOS 11 siri Chinese Female
            {name: 'Gordon', lang: 'en-AU'}, //381 iOS 10 siri Australian Male
            {name: 'Aaron', lang: 'en-US'}, //382 iOS 10 siri US English Male
            {name: 'Nicky', lang: 'en-US'}, //383 iOS 10 siri US English Female

            {name: 'Microsoft Hanhan Desktop - Chinese (Taiwan)', lang: 'zh-TW'}, //384 like 361 like 322, 305 Female Windows Chrome and Firefox variation on name
            {name: 'Microsoft Heami Desktop - Korean', lang: 'ko-KR'}, //385 like 362 like 323, 306 FemaleWindows Chrome and Firefox variation on name
            {name: 'Fallback Australian Male', lang: 'en-AU', fallbackvoice: true, service: 'g1', gender: 'male'}, //386 Australian Male fallback	
            {name: 'Fallback Russian Male', lang: 'ru', fallbackvoice: true, service: 'g1', gender: 'male'}, //387 Russian Male fallback	
            {name: 'Fallback Arabic Male', lang: 'ar', fallbackvoice: true, service: 'g1', gender: 'male'}, //388 Arabic Male fallback	
            {name: 'Fallback Chinese', lang: 'zh-CN', fallbackvoice: true, service: 'g1', gender: 'male'}, //389 Chinese Male fallback	
            {name: 'Fallback Chinese HK', lang: 'zh-HK', fallbackvoice: true, service: 'g1', gender: 'male'}, //390 Chinese HK Male fallback	
            {name: 'Fallback Chinese TW', lang: 'zh-TW', fallbackvoice: true, service: 'g1', gender: 'male'}, //391 Chinese TW Male fallback	
            {name: 'Fallback French Male', lang: 'fr', fallbackvoice: true, service: 'g1', gender: 'male'}, //392 French Male fallback								
            {name: 'Fallback Deutsch Male', lang: 'de', fallbackvoice: true, service: 'g1', gender: 'male'}, //393 Deutsch Male fallback			
            {name: 'Fallback Hindi Male', lang: 'hi', fallbackvoice: true, service: 'g1', gender: 'male'}, //394 Hindi Male fallback	
            {name: 'Fallback Indonesian Male', lang: 'id', fallbackvoice: true, service: 'g1', gender: 'male'}, //395 Indonesian Male fallback	
            {name: 'Fallback Japanese Male', lang: 'ja', fallbackvoice: true, service: 'g1', gender: 'male'}, //396 Japanese Male fallback	
            {name: 'Fallback Korean Male', lang: 'ko', fallbackvoice: true, service: 'g1', gender: 'male'}, //397 Korean Male fallback	
            {name: 'Fallback Polish Male', lang: 'pl', fallbackvoice: true, service: 'g1', gender: 'male'}, //398 Polish Male fallback	
            {name: 'Fallback Brazilian Portuguese Male', lang: 'pt-BR', fallbackvoice: true, service: 'g1', gender: 'male'}, //399 Brazilian Portugese Male fallback	
            {name: 'Fallback Portuguese Male', lang: 'pt-PT', fallbackvoice: true, service: 'g1', gender: 'male'}, //400 Portuguese Male fallback	
            {name: 'Fallback Spanish Male', lang: 'es', fallbackvoice: true, service: 'g1', gender: 'male'}, //401 Spanish Male fallback						
            {name: 'Fallback Spanish (Latin American) Male', lang: 'es-419', fallbackvoice: true, service: 'g1', gender: 'male'}, //402 Spanish (Latin American) Male fallback	
            {name: 'Fallback Thai Male', lang: 'th', fallbackvoice: true, service: 'g1', gender: 'male'}, //403 Thai Male fallback	
            {name: 'Fallback Turkish Male', lang: 'tr', fallbackvoice: true, service: 'g1', gender: 'male'}, //404 Turkish Male fallback	
            {name: 'Fallback Vietnamese Female', lang: 'vi', fallbackvoice: true, service: 'g1', gender: 'female'}, //405 Vietnamese Female fallback	
            {name: 'Fallback Italian Male', lang: 'it', fallbackvoice: true, service: 'g1', gender: 'male'}, //406 Italian Male fallback								
            {name: 'Fallback Dutch Male', lang: 'nl', fallbackvoice: true, timerSpeed:0, service: 'g1', gender: 'male'}, //407 Dutch Male fallback

        ];
        
        self.iOS = /(iPad|iPhone|iPod)/g.test(navigator.userAgent);
        self.iOS9  = /(iphone|ipod|ipad).* os 9_/.test(navigator.userAgent.toLowerCase());
        self.iOS10  = /(iphone|ipod|ipad).* os 10_/.test(navigator.userAgent.toLowerCase());
        self.iOS11  = /(iphone|ipod|ipad).* os 11_/.test(navigator.userAgent.toLowerCase());
        self.iOS9plus  = /(iphone|ipod|ipad).* os 10_/.test(navigator.userAgent.toLowerCase()) || /(iphone|ipod|ipad).* os 10_/.test(navigator.userAgent.toLowerCase());

        self.is_chrome = navigator.userAgent.indexOf('Chrome') > -1;
        self.is_safari = navigator.userAgent.indexOf("Safari") > -1;
        if ((self.is_chrome)&&(self.is_safari)) {self.is_safari=false;}
        self.is_opera = !!window.opera || navigator.userAgent.indexOf(' OPR/') >= 0;
        self.is_android = navigator.userAgent.toLowerCase().indexOf("android") > -1;
        
        self.iOS_initialized = false;
        self.iOS9_initialized = false;
        self.iOS10_initialized = false;
        self.iOS11_initialized = false;

        
        //Fallback cache voices
        self.cache_ios_voices = [{"name":"he-IL","voiceURI":"he-IL","lang":"he-IL"},{"name":"th-TH","voiceURI":"th-TH","lang":"th-TH"},{"name":"pt-BR","voiceURI":"pt-BR","lang":"pt-BR"},{"name":"sk-SK","voiceURI":"sk-SK","lang":"sk-SK"},{"name":"fr-CA","voiceURI":"fr-CA","lang":"fr-CA"},{"name":"ro-RO","voiceURI":"ro-RO","lang":"ro-RO"},{"name":"no-NO","voiceURI":"no-NO","lang":"no-NO"},{"name":"fi-FI","voiceURI":"fi-FI","lang":"fi-FI"},{"name":"pl-PL","voiceURI":"pl-PL","lang":"pl-PL"},{"name":"de-DE","voiceURI":"de-DE","lang":"de-DE"},{"name":"nl-NL","voiceURI":"nl-NL","lang":"nl-NL"},{"name":"id-ID","voiceURI":"id-ID","lang":"id-ID"},{"name":"tr-TR","voiceURI":"tr-TR","lang":"tr-TR"},{"name":"it-IT","voiceURI":"it-IT","lang":"it-IT"},{"name":"pt-PT","voiceURI":"pt-PT","lang":"pt-PT"},{"name":"fr-FR","voiceURI":"fr-FR","lang":"fr-FR"},{"name":"ru-RU","voiceURI":"ru-RU","lang":"ru-RU"},{"name":"es-MX","voiceURI":"es-MX","lang":"es-MX"},{"name":"zh-HK","voiceURI":"zh-HK","lang":"zh-HK"},{"name":"sv-SE","voiceURI":"sv-SE","lang":"sv-SE"},{"name":"hu-HU","voiceURI":"hu-HU","lang":"hu-HU"},{"name":"zh-TW","voiceURI":"zh-TW","lang":"zh-TW"},{"name":"es-ES","voiceURI":"es-ES","lang":"es-ES"},{"name":"zh-CN","voiceURI":"zh-CN","lang":"zh-CN"},{"name":"nl-BE","voiceURI":"nl-BE","lang":"nl-BE"},{"name":"en-GB","voiceURI":"en-GB","lang":"en-GB"},{"name":"ar-SA","voiceURI":"ar-SA","lang":"ar-SA"},{"name":"ko-KR","voiceURI":"ko-KR","lang":"ko-KR"},{"name":"cs-CZ","voiceURI":"cs-CZ","lang":"cs-CZ"},{"name":"en-ZA","voiceURI":"en-ZA","lang":"en-ZA"},{"name":"en-AU","voiceURI":"en-AU","lang":"en-AU"},{"name":"da-DK","voiceURI":"da-DK","lang":"da-DK"},{"name":"en-US","voiceURI":"en-US","lang":"en-US"},{"name":"en-IE","voiceURI":"en-IE","lang":"en-IE"},{"name":"hi-IN","voiceURI":"hi-IN","lang":"hi-IN"},{"name":"el-GR","voiceURI":"el-GR","lang":"el-GR"},{"name":"ja-JP","voiceURI":"ja-JP","lang":"ja-JP"}];
        self.cache_ios9_voices = [{name:"Maged",voiceURI:"com.apple.ttsbundle.Maged-compact",lang:"ar-SA",localService:!0,"default":!0},{name:"Zuzana",voiceURI:"com.apple.ttsbundle.Zuzana-compact",lang:"cs-CZ",localService:!0,"default":!0},{name:"Sara",voiceURI:"com.apple.ttsbundle.Sara-compact",lang:"da-DK",localService:!0,"default":!0},{name:"Anna",voiceURI:"com.apple.ttsbundle.Anna-compact",lang:"de-DE",localService:!0,"default":!0},{name:"Melina",voiceURI:"com.apple.ttsbundle.Melina-compact",lang:"el-GR",localService:!0,"default":!0},{name:"Karen",voiceURI:"com.apple.ttsbundle.Karen-compact",lang:"en-AU",localService:!0,"default":!0},{name:"Daniel",voiceURI:"com.apple.ttsbundle.Daniel-compact",lang:"en-GB",localService:!0,"default":!0},{name:"Moira",voiceURI:"com.apple.ttsbundle.Moira-compact",lang:"en-IE",localService:!0,"default":!0},{name:"Samantha (Enhanced)",voiceURI:"com.apple.ttsbundle.Samantha-premium",lang:"en-US",localService:!0,"default":!0},{name:"Samantha",voiceURI:"com.apple.ttsbundle.Samantha-compact",lang:"en-US",localService:!0,"default":!0},{name:"Tessa",voiceURI:"com.apple.ttsbundle.Tessa-compact",lang:"en-ZA",localService:!0,"default":!0},{name:"Monica",voiceURI:"com.apple.ttsbundle.Monica-compact",lang:"es-ES",localService:!0,"default":!0},{name:"Paulina",voiceURI:"com.apple.ttsbundle.Paulina-compact",lang:"es-MX",localService:!0,"default":!0},{name:"Satu",voiceURI:"com.apple.ttsbundle.Satu-compact",lang:"fi-FI",localService:!0,"default":!0},{name:"Amelie",voiceURI:"com.apple.ttsbundle.Amelie-compact",lang:"fr-CA",localService:!0,"default":!0},{name:"Thomas",voiceURI:"com.apple.ttsbundle.Thomas-compact",lang:"fr-FR",localService:!0,"default":!0},{name:"Carmit",voiceURI:"com.apple.ttsbundle.Carmit-compact",lang:"he-IL",localService:!0,"default":!0},{name:"Lekha",voiceURI:"com.apple.ttsbundle.Lekha-compact",lang:"hi-IN",localService:!0,"default":!0},{name:"Mariska",voiceURI:"com.apple.ttsbundle.Mariska-compact",lang:"hu-HU",localService:!0,"default":!0},{name:"Damayanti",voiceURI:"com.apple.ttsbundle.Damayanti-compact",lang:"id-ID",localService:!0,"default":!0},{name:"Alice",voiceURI:"com.apple.ttsbundle.Alice-compact",lang:"it-IT",localService:!0,"default":!0},{name:"Kyoko",voiceURI:"com.apple.ttsbundle.Kyoko-compact",lang:"ja-JP",localService:!0,"default":!0},{name:"Yuna",voiceURI:"com.apple.ttsbundle.Yuna-compact",lang:"ko-KR",localService:!0,"default":!0},{name:"Ellen",voiceURI:"com.apple.ttsbundle.Ellen-compact",lang:"nl-BE",localService:!0,"default":!0},{name:"Xander",voiceURI:"com.apple.ttsbundle.Xander-compact",lang:"nl-NL",localService:!0,"default":!0},{name:"Nora",voiceURI:"com.apple.ttsbundle.Nora-compact",lang:"no-NO",localService:!0,"default":!0},{name:"Zosia",voiceURI:"com.apple.ttsbundle.Zosia-compact",lang:"pl-PL",localService:!0,"default":!0},{name:"Luciana",voiceURI:"com.apple.ttsbundle.Luciana-compact",lang:"pt-BR",localService:!0,"default":!0},{name:"Joana",voiceURI:"com.apple.ttsbundle.Joana-compact",lang:"pt-PT",localService:!0,"default":!0},{name:"Ioana",voiceURI:"com.apple.ttsbundle.Ioana-compact",lang:"ro-RO",localService:!0,"default":!0},{name:"Milena",voiceURI:"com.apple.ttsbundle.Milena-compact",lang:"ru-RU",localService:!0,"default":!0},{name:"Laura",voiceURI:"com.apple.ttsbundle.Laura-compact",lang:"sk-SK",localService:!0,"default":!0},{name:"Alva",voiceURI:"com.apple.ttsbundle.Alva-compact",lang:"sv-SE",localService:!0,"default":!0},{name:"Kanya",voiceURI:"com.apple.ttsbundle.Kanya-compact",lang:"th-TH",localService:!0,"default":!0},{name:"Yelda",voiceURI:"com.apple.ttsbundle.Yelda-compact",lang:"tr-TR",localService:!0,"default":!0},{name:"Ting-Ting",voiceURI:"com.apple.ttsbundle.Ting-Ting-compact",lang:"zh-CN",localService:!0,"default":!0},{name:"Sin-Ji",voiceURI:"com.apple.ttsbundle.Sin-Ji-compact",lang:"zh-HK",localService:!0,"default":!0},{name:"Mei-Jia",voiceURI:"com.apple.ttsbundle.Mei-Jia-compact",lang:"zh-TW",localService:!0,"default":!0}];
        self.cache_ios10_voices = [{"name":"Maged","voiceURI":"com.apple.ttsbundle.Maged-compact","lang":"ar-SA"},{"name":"Zuzana","voiceURI":"com.apple.ttsbundle.Zuzana-compact","lang":"cs-CZ"},{"name":"Sara","voiceURI":"com.apple.ttsbundle.Sara-compact","lang":"da-DK"},{"name":"Anna","voiceURI":"com.apple.ttsbundle.Anna-compact","lang":"de-DE"},{"name":"Helena","voiceURI":"com.apple.ttsbundle.siri_female_de-DE_compact","lang":"de-DE"},{"name":"Martin","voiceURI":"com.apple.ttsbundle.siri_male_de-DE_compact","lang":"de-DE"},{"name":"Nikos (Enhanced)","voiceURI":"com.apple.ttsbundle.Nikos-premium","lang":"el-GR"},{"name":"Melina","voiceURI":"com.apple.ttsbundle.Melina-compact","lang":"el-GR"},{"name":"Nikos","voiceURI":"com.apple.ttsbundle.Nikos-compact","lang":"el-GR"},{"name":"Catherine","voiceURI":"com.apple.ttsbundle.siri_female_en-AU_compact","lang":"en-AU"},{"name":"Gordon","voiceURI":"com.apple.ttsbundle.siri_male_en-AU_compact","lang":"en-AU"},{"name":"Karen","voiceURI":"com.apple.ttsbundle.Karen-compact","lang":"en-AU"},{"name":"Daniel (Enhanced)","voiceURI":"com.apple.ttsbundle.Daniel-premium","lang":"en-GB"},{"name":"Arthur","voiceURI":"com.apple.ttsbundle.siri_male_en-GB_compact","lang":"en-GB"},{"name":"Daniel","voiceURI":"com.apple.ttsbundle.Daniel-compact","lang":"en-GB"},{"name":"Martha","voiceURI":"com.apple.ttsbundle.siri_female_en-GB_compact","lang":"en-GB"},{"name":"Moira","voiceURI":"com.apple.ttsbundle.Moira-compact","lang":"en-IE"},{"name":"Nicky (Enhanced)","voiceURI":"com.apple.ttsbundle.siri_female_en-US_premium","lang":"en-US"},{"name":"Samantha (Enhanced)","voiceURI":"com.apple.ttsbundle.Samantha-premium","lang":"en-US"},{"name":"Aaron","voiceURI":"com.apple.ttsbundle.siri_male_en-US_compact","lang":"en-US"},{"name":"Fred","voiceURI":"com.apple.speech.synthesis.voice.Fred","lang":"en-US"},{"name":"Nicky","voiceURI":"com.apple.ttsbundle.siri_female_en-US_compact","lang":"en-US"},{"name":"Samantha","voiceURI":"com.apple.ttsbundle.Samantha-compact","lang":"en-US"},{"name":"Tessa","voiceURI":"com.apple.ttsbundle.Tessa-compact","lang":"en-ZA"},{"name":"Monica","voiceURI":"com.apple.ttsbundle.Monica-compact","lang":"es-ES"},{"name":"Paulina","voiceURI":"com.apple.ttsbundle.Paulina-compact","lang":"es-MX"},{"name":"Satu","voiceURI":"com.apple.ttsbundle.Satu-compact","lang":"fi-FI"},{"name":"Amelie","voiceURI":"com.apple.ttsbundle.Amelie-compact","lang":"fr-CA"},{"name":"Daniel","voiceURI":"com.apple.ttsbundle.siri_male_fr-FR_compact","lang":"fr-FR"},{"name":"Marie","voiceURI":"com.apple.ttsbundle.siri_female_fr-FR_compact","lang":"fr-FR"},{"name":"Thomas","voiceURI":"com.apple.ttsbundle.Thomas-compact","lang":"fr-FR"},{"name":"Carmit","voiceURI":"com.apple.ttsbundle.Carmit-compact","lang":"he-IL"},{"name":"Lekha","voiceURI":"com.apple.ttsbundle.Lekha-compact","lang":"hi-IN"},{"name":"Mariska","voiceURI":"com.apple.ttsbundle.Mariska-compact","lang":"hu-HU"},{"name":"Damayanti","voiceURI":"com.apple.ttsbundle.Damayanti-compact","lang":"id-ID"},{"name":"Alice","voiceURI":"com.apple.ttsbundle.Alice-compact","lang":"it-IT"},{"name":"Hattori","voiceURI":"com.apple.ttsbundle.siri_male_ja-JP_compact","lang":"ja-JP"},{"name":"Kyoko","voiceURI":"com.apple.ttsbundle.Kyoko-compact","lang":"ja-JP"},{"name":"O-ren","voiceURI":"com.apple.ttsbundle.siri_female_ja-JP_compact","lang":"ja-JP"},{"name":"Yuna","voiceURI":"com.apple.ttsbundle.Yuna-compact","lang":"ko-KR"},{"name":"Ellen","voiceURI":"com.apple.ttsbundle.Ellen-compact","lang":"nl-BE"},{"name":"Xander","voiceURI":"com.apple.ttsbundle.Xander-compact","lang":"nl-NL"},{"name":"Nora","voiceURI":"com.apple.ttsbundle.Nora-compact","lang":"no-NO"},{"name":"Zosia","voiceURI":"com.apple.ttsbundle.Zosia-compact","lang":"pl-PL"},{"name":"Luciana","voiceURI":"com.apple.ttsbundle.Luciana-compact","lang":"pt-BR"},{"name":"Joana","voiceURI":"com.apple.ttsbundle.Joana-compact","lang":"pt-PT"},{"name":"Ioana","voiceURI":"com.apple.ttsbundle.Ioana-compact","lang":"ro-RO"},{"name":"Milena","voiceURI":"com.apple.ttsbundle.Milena-compact","lang":"ru-RU"},{"name":"Laura","voiceURI":"com.apple.ttsbundle.Laura-compact","lang":"sk-SK"},{"name":"Alva","voiceURI":"com.apple.ttsbundle.Alva-compact","lang":"sv-SE"},{"name":"Kanya","voiceURI":"com.apple.ttsbundle.Kanya-compact","lang":"th-TH"},{"name":"Yelda","voiceURI":"com.apple.ttsbundle.Yelda-compact","lang":"tr-TR"},{"name":"Li-mu","voiceURI":"com.apple.ttsbundle.siri_male_zh-CN_compact","lang":"zh-CN"},{"name":"Ting-Ting","voiceURI":"com.apple.ttsbundle.Ting-Ting-compact","lang":"zh-CN"},{"name":"Yu-shu","voiceURI":"com.apple.ttsbundle.siri_female_zh-CN_compact","lang":"zh-CN"},{"name":"Sin-Ji","voiceURI":"com.apple.ttsbundle.Sin-Ji-compact","lang":"zh-HK"},{"name":"Mei-Jia","voiceURI":"com.apple.ttsbundle.Mei-Jia-compact","lang":"zh-TW"}];
        self.cache_ios11_voices = [{"name":"Maged","voiceURI":"com.apple.ttsbundle.Maged-compact","lang":"ar-SA"},{"name":"Zuzana","voiceURI":"com.apple.ttsbundle.Zuzana-compact","lang":"cs-CZ"},{"name":"Sara","voiceURI":"com.apple.ttsbundle.Sara-compact","lang":"da-DK"},{"name":"Anna","voiceURI":"com.apple.ttsbundle.Anna-compact","lang":"de-DE"},{"name":"Helena","voiceURI":"com.apple.ttsbundle.siri_female_de-DE_compact","lang":"de-DE"},{"name":"Martin","voiceURI":"com.apple.ttsbundle.siri_male_de-DE_compact","lang":"de-DE"},{"name":"Melina","voiceURI":"com.apple.ttsbundle.Melina-compact","lang":"el-GR"},{"name":"Catherine","voiceURI":"com.apple.ttsbundle.siri_female_en-AU_compact","lang":"en-AU"},{"name":"Gordon","voiceURI":"com.apple.ttsbundle.siri_male_en-AU_compact","lang":"en-AU"},{"name":"Karen","voiceURI":"com.apple.ttsbundle.Karen-compact","lang":"en-AU"},{"name":"Arthur","voiceURI":"com.apple.ttsbundle.siri_male_en-GB_compact","lang":"en-GB"},{"name":"Daniel","voiceURI":"com.apple.ttsbundle.Daniel-compact","lang":"en-GB"},{"name":"Martha","voiceURI":"com.apple.ttsbundle.siri_female_en-GB_compact","lang":"en-GB"},{"name":"Moira","voiceURI":"com.apple.ttsbundle.Moira-compact","lang":"en-IE"},{"name":"Aaron","voiceURI":"com.apple.ttsbundle.siri_male_en-US_compact","lang":"en-US"},{"name":"Fred","voiceURI":"com.apple.speech.synthesis.voice.Fred","lang":"en-US"},{"name":"Nicky","voiceURI":"com.apple.ttsbundle.siri_female_en-US_compact","lang":"en-US"},{"name":"Samantha","voiceURI":"com.apple.ttsbundle.Samantha-compact","lang":"en-US"},{"name":"Tessa","voiceURI":"com.apple.ttsbundle.Tessa-compact","lang":"en-ZA"},{"name":"Monica","voiceURI":"com.apple.ttsbundle.Monica-compact","lang":"es-ES"},{"name":"Paulina","voiceURI":"com.apple.ttsbundle.Paulina-compact","lang":"es-MX"},{"name":"Satu","voiceURI":"com.apple.ttsbundle.Satu-compact","lang":"fi-FI"},{"name":"Amelie","voiceURI":"com.apple.ttsbundle.Amelie-compact","lang":"fr-CA"},{"name":"Daniel","voiceURI":"com.apple.ttsbundle.siri_male_fr-FR_compact","lang":"fr-FR"},{"name":"Marie","voiceURI":"com.apple.ttsbundle.siri_female_fr-FR_compact","lang":"fr-FR"},{"name":"Thomas","voiceURI":"com.apple.ttsbundle.Thomas-compact","lang":"fr-FR"},{"name":"Carmit","voiceURI":"com.apple.ttsbundle.Carmit-compact","lang":"he-IL"},{"name":"Lekha","voiceURI":"com.apple.ttsbundle.Lekha-compact","lang":"hi-IN"},{"name":"Mariska","voiceURI":"com.apple.ttsbundle.Mariska-compact","lang":"hu-HU"},{"name":"Damayanti","voiceURI":"com.apple.ttsbundle.Damayanti-compact","lang":"id-ID"},{"name":"Alice","voiceURI":"com.apple.ttsbundle.Alice-compact","lang":"it-IT"},{"name":"Hattori","voiceURI":"com.apple.ttsbundle.siri_male_ja-JP_compact","lang":"ja-JP"},{"name":"Kyoko","voiceURI":"com.apple.ttsbundle.Kyoko-compact","lang":"ja-JP"},{"name":"O-ren","voiceURI":"com.apple.ttsbundle.siri_female_ja-JP_compact","lang":"ja-JP"},{"name":"Yuna","voiceURI":"com.apple.ttsbundle.Yuna-compact","lang":"ko-KR"},{"name":"Ellen","voiceURI":"com.apple.ttsbundle.Ellen-compact","lang":"nl-BE"},{"name":"Xander","voiceURI":"com.apple.ttsbundle.Xander-compact","lang":"nl-NL"},{"name":"Nora","voiceURI":"com.apple.ttsbundle.Nora-compact","lang":"no-NO"},{"name":"Zosia","voiceURI":"com.apple.ttsbundle.Zosia-compact","lang":"pl-PL"},{"name":"Luciana","voiceURI":"com.apple.ttsbundle.Luciana-compact","lang":"pt-BR"},{"name":"Joana","voiceURI":"com.apple.ttsbundle.Joana-compact","lang":"pt-PT"},{"name":"Ioana","voiceURI":"com.apple.ttsbundle.Ioana-compact","lang":"ro-RO"},{"name":"Milena","voiceURI":"com.apple.ttsbundle.Milena-compact","lang":"ru-RU"},{"name":"Laura","voiceURI":"com.apple.ttsbundle.Laura-compact","lang":"sk-SK"},{"name":"Alva","voiceURI":"com.apple.ttsbundle.Alva-compact","lang":"sv-SE"},{"name":"Kanya","voiceURI":"com.apple.ttsbundle.Kanya-compact","lang":"th-TH"},{"name":"Yelda","voiceURI":"com.apple.ttsbundle.Yelda-compact","lang":"tr-TR"},{"name":"Li-mu","voiceURI":"com.apple.ttsbundle.siri_male_zh-CN_compact","lang":"zh-CN"},{"name":"Ting-Ting","voiceURI":"com.apple.ttsbundle.Ting-Ting-compact","lang":"zh-CN"},{"name":"Yu-shu","voiceURI":"com.apple.ttsbundle.siri_female_zh-CN_compact","lang":"zh-CN"},{"name":"Sin-Ji","voiceURI":"com.apple.ttsbundle.Sin-Ji-compact","lang":"zh-HK"},{"name":"Mei-Jia","voiceURI":"com.apple.ttsbundle.Mei-Jia-compact","lang":"zh-TW"}]
        
        self.systemvoices = null;

        self.CHARACTER_LIMIT = 100;
        self.VOICESUPPORT_ATTEMPTLIMIT = 5;
        self.voicesupport_attempts = 0;
        self.fallbackMode = false;
        self.WORDS_PER_MINUTE = 130;

        self.fallback_audio = null;
        self.fallback_playbackrate = 1;
        self.def_fallback_playbackrate = self.fallback_playbackrate;
        self.fallback_audiopool = [];
        self.msgparameters = null;
        self.timeoutId = null;
        self.OnLoad_callbacks = [];
        self.useTimer = false;
        self.utterances = [];
        self.userInteractionEvents = ["mousedown", "mouseup", "mousewheel", "keydown"];
        self.fallbackBufferLength = 5;

        self.tstCompiled = function(xy) { xy = 0; return eval("typeof x" + "y === 'undefined'"); }  
        
        self.fallbackServicePath = 'https://code.responsivevoice.org/' + (self.tstCompiled()?'':'develop/') + 'getvoice.php';

        
        //onvoiceschanged Deprecated: Only works on chrome and introduces glitches.
        /*
        //Wait until system voices are ready and trigger the event OnVoiceReady
        if (typeof speechSynthesis != 'undefined') {
            speechSynthesis.onvoiceschanged = function () {
                
                self.systemvoices = window.speechSynthesis.getVoices();
                console.log("OnVoiceReady - from onvoiceschanged");
               // console.log(self.OnVoiceReady);
                if (self.OnVoiceReady != null) {
                    self.OnVoiceReady.call();
                }
                
                
            };
        }*/

        self.default_rv = self.responsivevoices[0];

        self.debug = false;

        self.rvsMapped = false;

        self.forcedFallbackMode = false;
        self.speechAllowedByUser = true;

        //self.OnVoiceReady = null; // OnVoiceReady is meant to be defined externally 

        self.log = function (log) {
            if (self.debug) {
                console.log(log);
            }
        };

        self.init = function() {
            
            //Disable RV on IOS temporally
            /*if (self.iOS) {
                self.enableFallbackMode();
                return;
            }*/
            
            //Force using timers on Android
            if (self.is_android)
                self.useTimer = true;

            //Force Opera to fallback mode
            if (self.is_opera || typeof speechSynthesis === 'undefined') {
                //Needs to be output
                console.log('RV: Voice synthesis not supported');
                self.enableFallbackMode();
                
                

            } else {


                //Waiting a few ms before calling getVoices() fixes some issues with safari on IOS as well as Chrome
                setTimeout(function () {
                    var gsvinterval = setInterval(function () {

                        var v = window.speechSynthesis.getVoices();

                        if (v.length == 0 && (self.systemvoices == null || self.systemvoices.length == 0)) {
                            //Needs to be output
                            console.log('Voice support NOT ready');

                            self.voicesupport_attempts++;
                            if (self.voicesupport_attempts > self.VOICESUPPORT_ATTEMPTLIMIT) {
                                
                                clearInterval(gsvinterval);
                                
                                //On IOS, sometimes getVoices is just empty, but speech works. So we use a cached voice collection.
                                if (window.speechSynthesis != null) {
                                    
                                    if (self.iOS) {
                                        
                                        //Determine iOS version:
                                        if (self.iOS11) {
                                            //iOS 11
                                            self.systemVoicesReady(self.cache_ios11_voices);

                                        } else if (self.iOS10) {
                                            //iOS 10
                                            self.systemVoicesReady(self.cache_ios10_voices);

                                        } else if (self.iOS9) {
                                            //iOS 9
                                            self.systemVoicesReady(self.cache_ios9_voices);
                                            
                                        }else{
                                            //iOS <9
                                            self.systemVoicesReady(self.cache_ios_voices);
                                            
                                        }
                                        //Needs to be output
                                        console.log('RV: Voice support ready (cached)');
                                        
                                        
                                    }else{
                                        //Needs to be output
                                        console.log("RV: speechSynthesis present but no system voices found");
                                        self.enableFallbackMode();
                                    }
                                    
                                } else {
                                
                                    //We don't support voices. Using fallback
                                    self.enableFallbackMode();
                                }
                            }

                        } else {
                            //Needs to be output
                            console.log('RV: Voice support ready');
                            self.systemVoicesReady(v);
                            
                            clearInterval(gsvinterval);

                        }

                    }, 100);
                }, 100);
            }

            //Enable user interaction hooks by default on mobile and safari
            if (self.iOS || self.is_android || self.is_safari) {
                self.enableWindowClickHook();
            }

            self.Dispatch("OnLoad");
        }

        self.systemVoicesReady = function(v) {
            self.systemvoices = v;

            self.mapRVs();

            if (self.OnVoiceReady != null)
                self.OnVoiceReady.call();           // TO BE DEPRECATED
            
            self.Dispatch("OnReady");
            if (window.hasOwnProperty('dispatchEvent'))
                window.dispatchEvent(new Event("ResponsiveVoice_OnReady"));
        }

        self.enableFallbackMode = function() {

            self.fallbackMode = true;
            self.forcedFallbackMode = true;
            //Needs to be output
            console.log('RV: Enabling fallback mode');

            self.mapRVs();

            if (self.OnVoiceReady != null)
                self.OnVoiceReady.call();           // TO BE DEPRECATED

            self.Dispatch("OnReady");
            if (window.hasOwnProperty('dispatchEvent'))            
                window.dispatchEvent(new Event("ResponsiveVoice_OnReady"));

            self.Dispatch("OnServiceSwitched");
        }


        self.getVoices = function () {

            //Create voices array

            var v = [];

            for (var i = 0; i < self.responsivevoices.length; i++) {
                v.push({name: self.responsivevoices[i].name});
            }

            return v;

        }


        self.speak = function (text, voicename, parameters) {

            if (self.rvsMapped) {
              var serviceUsed = null;



                //all iOS initialization
               /* if (self.iOS && !self.iOS_initialized) {
                    self.log("Initializing ios10");
                    setTimeout(function(){ self.speak(text,voicename,parameters);},100);
                    self.clickEvent();
                    self.iOS_initialized = true;
                    return;
                }*/

              //Cancel previous speech if it's already playing
              if (self.isPlaying()){
                self.log("Cancelling previous speech");
                self.cancel();
                setTimeout(function() {
                    self.speak(text, voicename, parameters);
                },50);
                return;
              }


              //Clean text
              // Quotes " and ` -> '
              text = text.replace(/[\"\`]/gm,"'");

              self.msgparameters = parameters ||  {};
              self.msgtext = text;
              self.msgvoicename = voicename;

              self.onstartFired = false;

              //Support for multipart text (there is a limit on characters)
              var multipartText = [];

              if (text.length > self.CHARACTER_LIMIT) {

                var tmptxt = text;

                while (tmptxt.length > self.CHARACTER_LIMIT) {

                  //Split by common phrase delimiters
                  var p = tmptxt.search(/([:!¡?¿;\(\)\[\]—«»\n]+|\.[^0-9]+)/);
                  var part = '';

                  //Coludn't split by priority characters, try commas
                  if (p == -1 || p >= self.CHARACTER_LIMIT) {
                    p = tmptxt.search(/,[^0-9]+/);
                  }

                  //Check for spaces. If no spaces then split by 99 characters.
                  if (p== -1) {

                    if (tmptxt.search(' ')==-1)
                      p=99;
                  }

                  //Couldn't split by normal characters, then we use spaces
                  if (p == -1 || p >= self.CHARACTER_LIMIT) {

                    var words = tmptxt.split(' ');

                    for (var i = 0; i < words.length; i++) {

                      if (part.length + words[i].length + 1 > self.CHARACTER_LIMIT)
                        break;

                      part += (i != 0 ? ' ' : '') + words[i];

                    }

                  } else {

                    part = tmptxt.substr(0, p + 1);

                  }

                  tmptxt = tmptxt.substr(part.length, tmptxt.length - part.length);

                  multipartText.push(part);
                  //self.log(part.length + " - " + part);

                }
                //Add the remaining text
                if (tmptxt.length > 0) {
                  multipartText.push(tmptxt);
                }

              } else {

                //Small text
                multipartText.push(text);
              }
                console.log(multipartText);

                self.multipartText = multipartText;

              //Find system voice that matches voice name
              var rv;

              if (voicename == null) {
                rv = self.default_rv;
                self.setDefaultVoice(rv.name);
              } else {
                rv = self.getResponsiveVoice(voicename);
              }

              //Deprecated announcement
              if (rv.deprecated===true) {
                console.warn("ResponsiveVoice: Voice " + rv.name + " is deprecated and will be removed in future releases");
              }


              var profile = {};


              //Map was done so no need to look for the mapped voice
              if (rv.mappedProfile != null) {

                profile = rv.mappedProfile;

              } else {

                profile.systemvoice = self.getMatchedVoice(rv);
                profile.collectionvoice = {};

                if (profile.systemvoice == null) {
                  //Needs to be output
                  console.log('RV: ERROR: No voice found for: ' + voicename);
                  return;
                }
              }

              //Check we have permission to play audio (mobile)
              var speechAllowed = self.checkSpeechAllowed();

              if (!speechAllowed) {
                  self.scheduledSpeak = {text: text, voicename:voicename, parameters:parameters};
                  return;
              }


              //Prevent fallbackmode to play more than 1 speech at the same time
              if (self.fallbackMode && self.fallback_audiopool.length>0) {
                  self.clearFallbackPool();
              }

              self.msgprofile = profile;

              self.log('Voice picked: ' + self.msgprofile.systemvoice.name);
              //self.log("Start multipart play");

              self.utterances=[];
              self.fallbackChunks=[];

              //Play multipart text
              for (var i = 0; i < multipartText.length; i++) {

                if (!self.fallbackMode && self.getServiceEnabled(self.services.NATIVE_TTS)) {
                  //Use SpeechSynthesis
                  self.log('Using SpeechSynthesis');
                  serviceUsed = self.services.NATIVE_TTS;

                  //Create msg object
                  var msg = new SpeechSynthesisUtterance();
                  msg.voiceURI = profile.systemvoice.voiceURI;
                  msg.volume = self.selectBest([profile.collectionvoice.volume, profile.systemvoice.volume, 1]); // 0 to 1
                  msg.rate = self.selectBest([(self.iOS9plus?1:null), profile.collectionvoice.rate, profile.systemvoice.rate, 1]); // 0.1 to 10 ** override iOS 0.25 rate
                  msg.pitch = self.selectBest([profile.collectionvoice.pitch, profile.systemvoice.pitch, 1]); //0 to 2*/
                  msg.text = multipartText[i];
                  msg.lang = self.selectBest([profile.collectionvoice.lang, profile.systemvoice.lang]);
                  msg.rvIndex = i;
                  msg.rvTotal = multipartText.length;

                  if (i == 0) {
                    msg.onstart = self.speech_onstart;
                  }
                  self.msgparameters.onendcalled = false;

                  if (parameters != null) {
                    msg.voice = typeof parameters.voice !== 'undefined' ? parameters.voice : profile.systemvoice;;

                    if (i < multipartText.length - 1 && multipartText.length > 1) {
                      msg.onend = self.onPartEnd;
                      if (msg.hasOwnProperty("addEventListener"))
                        msg.addEventListener('end',self.onPartEnd);

                    } else {
                      msg.onend = self.speech_onend;
                      if (msg.hasOwnProperty("addEventListener"))
                        msg.addEventListener('end',self.speech_onend);
                    }

                    msg.onerror = parameters.onerror || function (e) {
                        self.log('RV: Unknow Error');
                        self.log(e);
                      };

                    // Validate int/float parameters and return defaults
                    parameters.rate   = self.validateParameters(parameters, 'rate');
                    parameters.pitch  = self.validateParameters(parameters, 'pitch');
                    parameters.volume = self.validateParameters(parameters, 'volume');

                    msg.onpause = parameters.onpause;
                    msg.onresume = parameters.onresume;
                    msg.onmark = parameters.onmark;
                    msg.onboundary = parameters.onboundary || self.onboundary;
                    msg.pitch = parameters.pitch!=null?parameters.pitch:msg.pitch;
                    if (self.iOS) {
                      msg.rate = (parameters.rate!=null?(parameters.rate*parameters.rate):1) * msg.rate;
                    }else{
                      msg.rate = (parameters.rate!=null?parameters.rate:1) * msg.rate;
                    }

                    msg.volume = parameters.volume!=null?parameters.volume:msg.volume;
                  } else {
                    self.log('No Params received for current Utterance');

                    msg.voice = profile.systemvoice;;

                    msg.onend = self.speech_onend;
                    msg.onboundary = self.onboundary;

                    msg.onerror = function (e) {
                      self.log('RV: Unknow Error');
                      self.log(e);
                    };
                  }

                  self.utterances.push(msg);

                  if (i==0)
                    self.currentMsg = msg;

                  //This needs to be output for stability
                  console.log(msg);

                  //setTimeout(function(){
                  //speechSynthesis.speak(msg);
                  //},0);
                  self.tts_speak(msg);
                } else if (self.fallbackMode && self.getServiceEnabled(self.services.FALLBACK_AUDIO)) {

                  serviceUsed = self.services.FALLBACK_AUDIO;

                  self.fallback_playbackrate = self.def_fallback_playbackrate;

                  var pitch = self.selectBest([profile.collectionvoice.pitch, profile.systemvoice.pitch, 1]) //0 to 2*/
                  var rate = self.selectBest([ (self.iOS9plus?1:null), profile.collectionvoice.rate, profile.systemvoice.rate, 1]) ; // 0.1 to 10 ** override iOS 0.25 rate
                  var volume = self.selectBest([profile.collectionvoice.volume, profile.systemvoice.volume, 1]); // 0 to 1
                  var extraParams;

                  if (parameters != null) {
                    pitch = (parameters.pitch!=null?parameters.pitch:1) * pitch;
                    rate = (parameters.rate!=null?parameters.rate:1) * rate;
                    volume = (parameters.volume!=null?parameters.volume:1) * volume;
                    extraParams = parameters.extraParams || null;
                  }
                  pitch /= 2;
                  rate /=2;
                  volume *=2;
                  pitch = Math.min(Math.max(pitch, 0), 1);
                  rate = Math.min(Math.max(rate, 0), 1);
                  volume = Math.min(Math.max(volume, 0), 1);
                  //self.log(volume);
                  //self.fallback_playbackrate = pitch;


                  var url = self.fallbackServicePath + '?t=' + encodeURIComponent(multipartText[i]) + '&tl=' + (profile.collectionvoice.lang || profile.systemvoice.lang || 'en-US') + '&sv=' + (profile.collectionvoice.service || profile.systemvoice.service || '') + '&vn=' + (profile.collectionvoice.voicename || profile.systemvoice.voicename || '') + '&pitch=' + pitch.toString()+ '&rate=' + rate.toString() + '&vol=' + volume.toString();
                  if (profile.collectionvoice.gender !== undefined) url += '&gender='+profile.collectionvoice.gender;

                  if (extraParams) {
                    url += "&extraParams=" + JSON.stringify(extraParams);
                  }



                  self.fallbackChunks.push ({
                      text: multipartText[i],
                      url: url,
                      audio: null //not assigned yet
                  });


                  //self.log(audio);


                }


              }

              if (self.fallbackMode && self.getServiceEnabled(self.services.FALLBACK_AUDIO)) {


                self.fallbackChunkIndex = 0;
                self.fallback_startPart();

              }

              //Log service used
              self.log("Service used: " + serviceUsed);
            } else {
                var rvCheck = setTimeout(function() {
                    self.speak(text, voicename, parameters);
                }, 15);
            }
        }

        self.startTimeout = function (text, callback) {
            //if (self.iOS) {
            //   multiplier = 0.5;
            //}

            var multiplier = self.msgprofile.collectionvoice.timerSpeed;
            if (self.msgprofile.collectionvoice.timerSpeed==null)
                multiplier = 1;

            //self.log(self.msgprofile.collectionvoice.name);
            if (multiplier <=0)
                return;

            self.timeoutId = setTimeout(callback, self.getEstimatedTimeLength(text, multiplier));
            self.log("Timeout ID: " + self.timeoutId);
        }

        self.checkAndCancelTimeout = function () {
            if (self.timeoutId != null) {
                //self.log("Timeout " + self.timeoutId + " cancelled");
                clearTimeout(self.timeoutId);
                self.timeoutId = null;
            }
        }

        self.speech_timedout = function() {
            //self.log("Speech cancelled: Timeout " + self.timeoutId + " ended");
            self.cancel();
            self.cancelled = false;
            //if (!self.iOS) //On iOS, cancel calls msg.onend 
                self.speech_onend();
            
        }

        self.speech_onend = function () {
            self.checkAndCancelTimeout();
            
            //Avoid this being automatically called just after calling speechSynthesis.cancel
            if (self.cancelled === true) {
                self.cancelled = false;
                return;
            }
            
            self.log("on end fired");

            if (self.msgparameters != null && self.msgparameters.onend != null && self.msgparameters.onendcalled!=true) {
                self.log("Speech on end called  -" + self.msgtext);
                self.msgparameters.onendcalled=true;
                self.msgparameters.onend();
                
            } 

        }

        self.speech_onstart = function () {
            //Start can be triggered after onboundary!
            if (self.onstartFired) return
            
            self.onstartFired = true;
            //if (!self.iOS)
            self.log("Speech start");
            if (self.iOS || self.is_safari || self.useTimer) {
                if (!self.fallbackMode)
                    self.startTimeout(self.msgtext,self.speech_timedout);
                    
            }
                
            
            self.msgparameters.onendcalled=false;
            if (self.msgparameters != null && self.msgparameters.onstart != null) {
                self.msgparameters.onstart();
            }

        }



        self.fallback_startPart = function () {

            if (self.fallbackChunkIndex == 0) {
                self.speech_onstart();
            }

            self.fallback_updateChunksBuffer();

            self.fallback_audio = self.fallbackChunks[self.fallbackChunkIndex].audio;
            
            if (self.fallback_audio == null) {

                //Fallback audio is not working. Just wait for the timeout event
                self.log("RV: Fallback Audio is not available");

            } else {

                (function() {
                    var audio = self.fallback_audio;

                    //Add to pool to prevent multiple streams to be played at the same time
                    //self.fallback_audiopool.push(audio);

                    setTimeout(function () {
                        audio.playbackRate = self.fallback_playbackrate;
                    }, 50)
                    audio.onloadedmetadata = function () {
                        //audio.play();
                        audio.playbackRate = self.fallback_playbackrate;
                    };
                    if (audio.readyState>=2) {
                        audio.play();
                    }else {
                        var canPlay = function () {
                            audio.play();
                            audio.removeEventListener('canplaythrough', canPlay);
                        };
                        audio.addEventListener('canplaythrough', canPlay, false);
                    }
                })();
                /*self.fallback_audio.addEventListener('error', function (e) {
                    switch (e.target.error.code) {
                         case e.target.error.MEDIA_ERR_ABORTED:
                           self.log("RV: Error playing the file (aborted)");
                           break;
                         case e.target.error.MEDIA_ERR_NETWORK:
                           self.log("RV: Error playing the file (network)");
                           break;
                         case e.target.error.MEDIA_ERR_DECODE:
                           self.log("RV: Error playing the file (decode)");
                           break;
                         case e.target.error.MEDIA_ERR_SRC_NOT_SUPPORTED:
                           
                            self.log("RV: Error playing the file (not supported), skipping");
                            // audio playback failed. End speech
                            setTimeout(function(){
                                self.speech_onend();
                                self.fallback_errors = true;
                            },10);
                           
                           break;
                         default:
                           self.log("RV: Error playing the file (unknown)");
                           break;
                       }                    
                }, true);*/
                if (self.fallback_errors) {
                    self.log("RV: Speech cancelled due to errors");
                    self.speech_onend();
                }
                //self.fallback_audio.play();
                self.fallback_audio.addEventListener('ended', self.fallback_finishPart);
                    
                if (self.useTimer)
                    self.startTimeout(self.multipartText[self.fallbackChunkIndex], self.fallback_finishPart);
                
            }
        }
        
        /**
         * returns true if any of the fallback audio parts is currently playing
         */
        self.isFallbackAudioPlaying = function () {
            var c;

            for (c = 0; c < self.fallback_audiopool.length; c++) {
                var audio = self.fallback_audiopool[c];
                
                if (audio.paused || audio.ended || (audio.currentTime==audio.duration)) {
                    //Any of those means audio is not playing
                }else{
                    return true;
                }
            }

            return false;
        };

        self.fallback_finishPart = function (e) {
            /**
             * don't overlap audios
             */
            if (self.isFallbackAudioPlaying()) {
                self.checkAndCancelTimeout();
                self.timeoutId = setTimeout(self.fallback_finishPart, (self.fallback_audio.duration - self.fallback_audio.currentTime) * 1000);
                return;
            }



            self.checkAndCancelTimeout();

            if (self.fallbackChunkIndex < self.fallbackChunks.length - 1) {
                //self.log('chunk ended');
                self.fallbackChunkIndex++;
                self.fallback_startPart();

            } else {
                //self.log('msg ended');
                self.speech_onend();

            }

        }


        self.cancel = function () {

            self.checkAndCancelTimeout();

            if (self.fallbackMode){
                if (self.fallback_audio!=null)
                    self.fallback_audio.pause();
                self.clearFallbackPool();
            }else{
                self.cancelled = true;
                speechSynthesis.cancel();

            }
        }


        self.voiceSupport = function () {

            return ('speechSynthesis' in window);

        }

        self.OnFinishedPlaying = function (event) {
            //self.log("OnFinishedPlaying");
            if (self.msgparameters != null) {
                if (self.msgparameters.onend != null)
                    self.msgparameters.onend();
            }

        }

        //Set default voice to use when no voice name is supplied to speak()
        self.setDefaultVoice = function (voicename) {
            if (self.rvsMapped) {
                var rv = self.getResponsiveVoice(voicename);

                if (rv != null) {
                    self.default_rv = rv;
                }
            } else {
                var rvCheck = setTimeout(function() {
                    self.setDefaultVoice(voicename);
                }, 15);
            }
        }

        //Map responsivevoices to system voices
        self.mapRVs = function() {

            for (var i = 0; i < self.responsivevoices.length; i++) {

                var rv = self.responsivevoices[i];

                for (var j = 0; j < rv.voiceIDs.length; j++) {

                    var vcoll = self.voicecollection[rv.voiceIDs[j]];

                    if (vcoll.fallbackvoice != true) {		// vcoll.fallbackvoice would be null instead of false

                        // Look on system voices
                        var v = self.getSystemVoice(vcoll.name);

                        //Forcing fallback mode: force ignore system voices
                        if (self.forcedFallbackMode) {
                            v = null;
                        }

                        if (v != null) {
                            rv.mappedProfile = {
                                systemvoice: v,
                                collectionvoice: vcoll
                            };
                            //self.log("Mapped " + rv.name + " to " + v.name);
                            break;
                        }

                    } else {

                        //Pick the fallback voice
                        rv.mappedProfile = {
                            systemvoice: {},
                            collectionvoice: vcoll
                        };
                        //self.log("Mapped " + rv.name + " to " + vcoll.lang + " fallback voice");
                        break;

                    }
                }
            }
            self.rvsMapped = true;
        }


        //Look for the voice in the system that matches the one in our collection
        self.getMatchedVoice = function(rv) {

            for (var i = 0; i < rv.voiceIDs.length; i++) {
                var v = self.getSystemVoice(self.voicecollection[rv.voiceIDs[i]].name);
                if (v != null)
                    return v;
            }

            return null;

        }

        self.getSystemVoice = function (name) {
            var encodedName = '';
            var unicodeWhiteSpace = String.fromCharCode(160),
                encodedName = name.replace(new RegExp('\\s+|' + unicodeWhiteSpace, 'g'), '');

            if (typeof self.systemvoices === 'undefined' || self.systemvoices === null) {
                return null;
            }

            for (var i = 0; i < self.systemvoices.length; i++) {
                //Simple compare first
                if (0 === self.systemvoices[i].name.localeCompare(name)) {
                    return self.systemvoices[i];
                }
                //Try to match chromes asian language space charaacters
                if (0 === self.systemvoices[i].name.replace(new RegExp('\\s+|' + unicodeWhiteSpace, 'g'), '').replace(/ *\([^)]*\) */g, "").localeCompare(encodedName)) {
                    return self.systemvoices[i];
                }
            }

            //Not found by name. Try lang (iOS9) -- mixes up chrome voices with android voices
            /*for (var i = 0; i < self.systemvoices.length; i++) {
                if (self.systemvoices[i].lang == name)
                    return self.systemvoices[i];
            }*/

            return null;

        }

        self.getResponsiveVoice = function(name) {

            for (var i = 0; i < self.responsivevoices.length; i++) {
                if (self.responsivevoices[i].name == name) {

                    var lastFbMode = self.fallbackMode;

                    //set fallbackMode and parts, used when the profile fallbackvoice is true or when fallbackMode is forced
                    if (self.responsivevoices[i].mappedProfile.collectionvoice.fallbackvoice === true || self.forcedFallbackMode === true) {
                        self.fallbackMode = true;
                    } else {
                        self.fallbackMode = false;
                    }

                    //Map RVs again if we are switching in or out of fallbackMode
                    if (lastFbMode != self.fallbackMode) {

                        self.mapRVs();
                        self.Dispatch("OnServiceSwitched");
                    }

                    return self.responsivevoices[i];
                }
            }

            return null;

        }
        
        self.Dispatch = function(name) {
            //self.log("Dispatching " +name);
            if (self.hasOwnProperty(name + "_callbacks") && 
                self[name + "_callbacks"] != null &&     
                self[name + "_callbacks"].length > 0) {
                var callbacks = self[name + "_callbacks"];
                for(var i=0; i<callbacks.length; i++) {
                    callbacks[i]();
                }
                //self.log("Dispatched " + name);
                return true;
            }else {
                //Try calling a few ms later
                var timeoutName = name + "_callbacks_timeout";
                var timeoutCount = name + "_callbacks_timeoutCount";
                if (self.hasOwnProperty(timeoutName)) {
                    
                }else{
                    //self.log("Setting up timeout for " + name);
                    self[timeoutCount] = 10;
                    self[timeoutName] = setInterval(function() {
                        //self.log("Timeout function for " + name)
                        self[timeoutCount] = self[timeoutCount] - 1;
                        
                        if (self.Dispatch(name) || self[timeoutCount]<0) {
                            clearTimeout(self[timeoutName]);
                            //if (self[timeoutCount]<0) self.log("Timeout ran out");
                        } else{
                           //self.log("Keep waiting..." + name);
                        }
                    },50);
                }
                
                
                //self.log("not found");
                return false;
            }
        }
        
        self.AddEventListener = function(name,callback) {
            if (!self.hasOwnProperty(name + "_callbacks")) {
                self[name + "_callbacks"] = [];
            }
            self[name + "_callbacks"].push(callback);
        }
        
        self.addEventListener = self.AddEventListener;

        self.RemoveEventListener = function(name, callback) {
            if (self[name + "_callbacks"] && self[name + "_callbacks"].indexOf(callback) != -1 ) {
                self[name + "_callbacks"].splice(self[name + "_callbacks"].indexOf(callback), 1);
            }
        }
        
        //Event designed to be hooked to any click event on the page and initialize permission to play audio
        // iOS: Needed to play TTS
        // Android: Needed to play audio files
        self.clickEvent = function() {
            self.log("Click event");
            self.click_event_detected = true;

            self.initializePermissions();

            //Remove hooks
            self.userInteractionEvents.forEach(function(event) {
                window.removeEventListener(event, self.clickEvent, false);
            });

            self.Dispatch("OnClickEvent");
            
        }

        self.initializePermissions = function() {

            //TTS
            if (self.iOS && !self.iOS_initialized) {
                self.log("Initializing iOS click event");
                var u = new SpeechSynthesisUtterance(" ");
                speechSynthesis.speak(u);
                self.iOS_initialized = true;
            }

            if (self.is_android && !self.android_initialized) {
                self.log("Initializing Android click event");
                var u = new SpeechSynthesisUtterance(" ");
                speechSynthesis.speak(u);
            }

            //Fallback
            self.initFallbackPool();

        }
        
        self.isPlaying = function() {
            if (self.fallbackMode) {
                
                return  (self.fallback_audio!=null &&
                        !self.fallback_audio.ended &&
                        !self.fallback_audio.paused);
                
            }else{
                
                return speechSynthesis.speaking;
                
            }
        }
        
        self.clearFallbackPool = function() {
            
            for (var i=0; i<self.fallback_audiopool.length; i++) {
                
                if (self.fallback_audiopool[i]!=null) {
                    self.fallback_audiopool[i].pause();
                    self.fallback_audiopool[i].src='';
                    //self.fallback_audiopool[i].parentElement.removeChild(self.fallback_audiopool[i]);
                }
            }
            //self.fallback_audiopool = [];
            self.fallback_audiopool_index = 0;
            self.fallbackChunks = [];
        }

        self.initFallbackPool = function() {
            //console.log("Init fallback pool");

            if (!self.fallback_audiopool || self.fallback_audiopool.length==0) {
                var poolLength = 10;

                for (var i = 0; i < poolLength; i++) {
                    (function(i) {
                        var audio = document.createElement("AUDIO");
                        audio.preload = 'auto';



                        //Only initialize them with sound on android (as this is triggered by the first user click)
                        if (self.is_android) {

                            audio.src = "";
                            audio.load();

                            //audio.play();
                            /*var canPlayCallback = function () {
                                audio.play();
                                audio.removeEventListener('canplaythrough', canPlayCallback);
                            }
                            audio.addEventListener('canplaythrough', canPlayCallback, false);

                            if (i == 0) {
                                var initializedCallback = function () {
                                    self.log("Android audio initialized");
                                    self.android_initialized = true;
                                    audio.removeEventListener('ended', initializedCallback);
                                };
                                audio.addEventListener('ended', initializedCallback);
                            }*/

                            //It seems we don't even need to play the audio, just loading an empty src does the trick
                            if (i==poolLength-1) {
                                self.log("Android HTML audio initialized");
                                self.android_initialized = true;
                            }

                        }

                        if (self.iOS) {

                            audio.src = "";
                            audio.load();

                            //audio.play();
                            /*var canPlayCallback = function () {
                             audio.play();
                             audio.removeEventListener('canplaythrough', canPlayCallback);
                             }
                             audio.addEventListener('canplaythrough', canPlayCallback, false);

                             if (i == 0) {
                             var initializedCallback = function () {
                             self.log("Android audio initialized");
                             self.android_initialized = true;
                             audio.removeEventListener('ended', initializedCallback);
                             };
                             audio.addEventListener('ended', initializedCallback);
                             }*/

                            //It seems we don't even need to play the audio, just loading an empty src does the trick
                            if (i==poolLength-1) {
                                self.log("iOS HTML audio initialized");
                                self.iOS_initialized = true;
                            }
                        }

                        self.fallback_audiopool.push(audio);
                    })(i);

                }

                self.fallback_audiopool_index = 0;
            }

        }

        self.allowSpeechClicked = function(value) {
            self.allowSpeechDiv.parentNode.removeChild(self.allowSpeechDiv);
            self.allowSpeechDiv = null;

            self.speechAllowedByUser = value;

            if (value) {
                self.clickEvent();
                if (self.scheduledSpeak) {
                    self.speak(self.scheduledSpeak.text, self.scheduledSpeak.voicename, self.scheduledSpeak.parameters);
                    self.scheduledSpeak = null;
                }
            }

            self.Dispatch("OnAllowSpeechClicked");
        }

        self.checkSpeechAllowed = function(options) {

            //If the user explicitly denied access
            if (self.speechAllowedByUser==false) {
                return false;
            }

            //If we are on mobile we can only initialize audio from a user action.
            //If it didn't happen it means speak was called without any user interaction so we need to force it.
            //Also applies to safari (html5 audio only)
            if ( ((self.is_android || self.iOS) ||              //Mobile
                (self.is_safari && (self.fallbackMode || self.forcedFallbackMode)) //Safai but only fallback
                ) && !self.click_event_detected) {
                //self.enableWindowClickHook();

                if (self.allowSpeechDiv) return;

                self.allowSpeechDiv_appearances = self.allowSpeechDiv_appearances==null?1:++self.allowSpeechDiv_appearances;
                if (self.allowSpeechDiv_appearances>2) {
                    console.log("ResponsiveVoice: Speech not allowed by user");
                    return false;
                }

                var cssnode = document.createElement('style');
                cssnode.innerHTML = '.rvNotification{position:fixed;background-color:#fff;text-align:center;font-family:-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif;font-weight:400;line-height:1.5;box-shadow:0 4px 8px 0 rgba(0,0,0,.2),0 6px 20px 0 rgba(0,0,0,.19);z-index:10000;width:100vw;left:0;bottom:0;font-size:1rem;padding-bottom:.5em;padding-right:.5em}.rvButtonRow{padding-right:2em;padding-bottom:1em;text-align:right;font-size:medium}.rvButton{RefCursor:pointer;display:inline-block;margin-left:1em;padding:.8em 2em;border-radius:3px;font-size:small}.rvButtonAllow{border:none;background-color:#2b8cff;color:#fff}.rvButtonDeny{border:1px solid #2b8cff;color:#2b8cff;background-color:#fff}.rvTextRow{padding-top:1em;padding-bottom:2em}@media (min-width:576px){.rvNotification{width:60vw;left:20vw}}@media (min-width:768px){.rvNotification{width:50vw;left:25vw}}@media (min-width:992px){.rvNotification{width:40vw;left:30vw}}@media (min-width:1200px){.rvNotification{width:30vw;left:35vw}}';
                document.body.appendChild(cssnode);

                self.allowSpeechDiv = document.createElement("div");
                self.allowSpeechDiv.classList.add('rvNotification');

                if(options == undefined) {
                    options = {};
                }
                var origin = options.urlOverride != undefined ? options.urlOverride : window.location.hostname;
                var action = options.textOverride != undefined ? options.textOverride : 'wants to play speech';

                self.allowSpeechDiv.innerHTML = '<div class="rvTextRow"><strong>' + origin + '</strong> ' + action + '</div><div class="rvButtonRow"><div onclick="responsiveVoice.allowSpeechClicked(false);" class="rvButton rvButtonDeny">DENY</div><div onclick="responsiveVoice.allowSpeechClicked(true);" class="rvButton rvButtonAllow">ALLOW</div></div>';
                document.body.appendChild(self.allowSpeechDiv);

                return false;
            }
            return true;
        }



        self.fallback_audioPool_getAudio = function() {
            self.initFallbackPool();
            if (self.fallback_audiopool_index>=self.fallback_audiopool.length) {
                //Pool is ended. We clear it
                //self.log("Audio pool capacity over. Reusing from index 0");
                self.fallback_audiopool_index = 0;
            }
            return self.fallback_audiopool[self.fallback_audiopool_index++];
        };

        self.fallback_updateChunksBuffer = function() {

            //Make sure we are ahead loading chunks
            for (var i = self.fallbackChunkIndex; i < Math.min(self.fallbackChunks.length, self.fallbackChunkIndex + self.fallbackBufferLength) ; i++) {
                var c = self.fallbackChunks[i];
                if (c.audio==null) {
                    c.audio = self.fallback_audioPool_getAudio();
                    //Load the audio
                    c.audio.src = c.url;
                    c.audio.playbackRate = self.fallback_playbackrate;
                    c.audio.preload = 'auto';
                    c.audio.load(); // android doesn't allow playing audio without an user action. this initializes all audio chunks at first action so restriction is removed.
                }
            }
            

        }
        
        self.selectBest = function(a) {
            
            for(var i=0; i<a.length; i++) {
                if (a[i]!=null) return a[i];
            }
            return null;
        }


        self.pause = function() {
            
            if (self.fallbackMode) {
                if (self.fallback_audio!=null) {
                    self.fallback_audio.pause();
                }
            }else{
                speechSynthesis.pause();
            }
        
        }
        
        self.resume = function() {
            if (self.fallbackMode) {
                if (self.fallback_audio!=null) {
                    self.fallback_audio.play();
                }
            }else{
                speechSynthesis.resume();
            }           
            
        }
        
        self.tts_speak = function(msg) {
            
            setTimeout(function(){
                self.cancelled = false;
                speechSynthesis.speak(msg);
            },0.01);
            
        }
        
        self.setVolume = function(v) {
            
            if (self.isPlaying()) {
                if (self.fallbackMode) {
                    for (var i=0; i<self.fallback_audiopool.length; i++) {
                        self.fallback_audiopool[i].volume = v;
                    }                    
                    self.fallback_audio.volume = v;
                }else{
                    for (var i=0; i<self.utterances.length; i++) {
                        self.utterances[i].volume = v;
                    }
                }
            }
        }
        
        self.onPartEnd = function(e) {
            
            if (self.msgparameters!=null && self.msgparameters.onchuckend!=null) {
                self.msgparameters.onchuckend();
            }
            
            self.Dispatch("OnPartEnd");
            
            var i = self.utterances.indexOf(e.utterance);
            self.currentMsg = self.utterances[i+1];
            
        }
        
        self.onboundary = function(e) {
            self.log("On Boundary");
            
            //on iOS on boundary sometimes will be fired when start hasn't. We use this as a false start.
            if (self.iOS && !self.onstartFired) {
                self.speech_onstart();
            }
            
        }

        self.numToWords = function (n) {
            var _slicedToArray = function () { function sliceIterator(arr, i) { var _arr = []; var _n = true; var _d = false; var _e = undefined; try { for (var _i = arr[Symbol.iterator](), _s; !(_n = (_s = _i.next()).done); _n = true) { _arr.push(_s.value); if (i && _arr.length === i) break; } } catch (err) { _d = true; _e = err; } finally { try { if (!_n && _i["return"]) _i["return"](); } finally { if (_d) throw _e; } } return _arr; } return function (arr, i) { if (Array.isArray(arr)) { return arr; } else if (Symbol.iterator in Object(arr)) { return sliceIterator(arr, i); } else { throw new TypeError("Invalid attempt to destructure non-iterable instance"); } }; }();

            function _toConsumableArray(arr) { if (Array.isArray(arr)) { for (var i = 0, arr2 = Array(arr.length); i < arr.length; i++) { arr2[i] = arr[i]; } return arr2; } else { return Array.from(arr); } }

            var arr = function arr(x) {
                return Array.from(x);
            };

            var num = function num(x) {
                return Number(x) || 0;
            };

            var isEmpty = function isEmpty(xs) {
                return xs.length === 0;
            };

            var take = function take(n) {
                return function (xs) {
                    return xs.slice(0, n);
                };
            };

            var drop = function drop(n) {
                return function (xs) {
                    return xs.slice(n);
                };
            };

            var reverse = function reverse(xs) {
                return xs.slice(0).reverse();
            };

            var comp = function comp(f) {
                return function (g) {
                    return function (x) {
                        return f(g(x));
                    };
                };
            };

            var not = function not(x) {
                return !x;
            };

            var chunk = function chunk(n) {
                return function (xs) {
                    return isEmpty(xs) ? [] : [take(n)(xs)].concat(_toConsumableArray(chunk(n)(drop(n)(xs))));
                };
            };

            var a = ['', 'one', 'two', 'three', 'four', 'five', 'six', 'seven', 'eight', 'nine', 'ten', 'eleven', 'twelve', 'thirteen', 'fourteen', 'fifteen', 'sixteen', 'seventeen', 'eighteen', 'nineteen'];

            var b = ['', '', 'twenty', 'thirty', 'forty', 'fifty', 'sixty', 'seventy', 'eighty', 'ninety'];

            var g = ['', 'thousand', 'million', 'billion', 'trillion', 'quadrillion', 'quintillion', 'sextillion', 'septillion', 'octillion', 'nonillion'];

            // this part is really nasty still
            // it might edit this again later to show how Monoids could fix this up
            var makeGroup = function makeGroup(_ref) {
                var _ref2 = _slicedToArray(_ref, 3);

                var ones = _ref2[0];
                var tens = _ref2[1];
                var huns = _ref2[2];

                return [num(huns) === 0 ? '' : a[huns] + ' hundred ', num(ones) === 0 ? b[tens] : b[tens] && b[tens] + ' ' || '', a[tens + ones] || a[ones]].join('');
            };

            var thousand = function thousand(group, i) {
                return group === '' ? group : group + ' ' + g[i];
            };

            if (typeof n === 'number') return self.numToWords(String(n));else if (n === '0') return 'zero';else return comp(chunk(3))(reverse)(arr(n)).map(makeGroup).map(thousand).filter(comp(not)(isEmpty)).reverse().join(' ').trim();
        };

        self.getWords = function (text) {

            //Process currencies
            text = text.replace(/$|¥|₡|€|£|₪|₹|￥|៛|₩|₦|฿|₴|₫/gi, " dummy currency ");

            var words = text.split(/(\s*[\s,]\s*|\?|;|:|\.|\(|\)|!)/),
                match;

            words = words.filter(function(str) {
                return /[^\s]/.test(str);
            });

            //find numbers, translate them to text, push as words
            for (var i = 0; i < words.length; i++) {
                if ((match = words[i].toString().match(/\d+/)) != null) {
                    words.splice(i, 1);
                    self.numToWords(+match[0]).split(/\s+/).map(function (word){
                        words.push(word);
                    });
                }
            }

            return words;
        };

        self.getEstimatedTimeLength = function (text, multiplier) {
            var words = self.getWords(text),
                charsCount = 0,
                base = self.fallbackMode ? 1300 : 700,
                multiplier = multiplier || 1/*, minWordLengthInText = 0, maxWordLengthInText = 0*/;

            words.map(function (word, i){
                charsCount += (word.toString().match(/[^ ]/igm) || word).length;

                 /*self.log(minWordLengthInText, maxWordLengthInText);

                 if (minWordLengthInText > 0 && minWordLengthInText > word.length) {
                 minWordLengthInText = word.length;
                 } else if (maxWordLengthInText > 0 && maxWordLengthInText < word.length) {
                 maxWordLengthInText = word.length;
                 } else if (minWordLengthInText == 0 && maxWordLengthInText == 0) {
                 minWordLengthInText = maxWordLengthInText = word.length;
                 }*/
            });

            //self.log("Words: [" + words + "], charsCount: " + charsCount);

            var wordsCount = words.length;
            //var avgWordLengthInText = (minWordLengthInText + maxWordLengthInText) / 2;

            //self.log(minWordLengthInText, maxWordLengthInText, avgWordLengthInText);

            //var wlf = (charsCount/wordsCount) / avgWordLengthInText * 5.1; //word length factor: 5.1 is the average word length in english.

            var estimatedLength = multiplier * 1000 * (60 / self.WORDS_PER_MINUTE) * wordsCount /** wlf*/;

            if (wordsCount < 5) {
                estimatedLength = multiplier * (base + charsCount * 50);
            }

            self.log("Estimated time length: " + estimatedLength + " ms, words: [" + words + "], charsCount: " + charsCount);

            return estimatedLength;
        };

        /**
         * Receives parameter name and value to check types.
         * Currently checks [rate, pitch, volume] for the native JS type "Number".
         * Returns unchanged value OR default "1" and outputs a warning on the console.
         * @param parameters
         * @param name
         * @returns {*}
         */
        self.validateParameters = function (parameters, name) {

            if (typeof parameters[name] === 'undefined'){
                return parameters[name];
            }

            // Leaving in a switch-case for future fine-tuning of individual parameters
            switch (name) {
                case 'rate':
                case 'pitch':
                case 'volume':
                    var test = Number(parameters[name]);

                    if (isNaN(test)) {
                        console.warn(
                            'ResponsiveVoice: the parameter ' + name + ' has a wrong value "' + parameters[name] + '". Defaults were used.'
                        );
                    }
                    parameters[name] = isNaN(test) ? "1" : parameters[name];
            }

            return parameters[name];
        };

        self.services = {
            NATIVE_TTS:     0,
            FALLBACK_AUDIO: 1
        };
        
        self.servicesPriority = [0, 1];
        self.servicesEnabled = [];
        
        self.setServiceEnabled = function(service,enabled) {
            self.servicesEnabled[service] = enabled;
        };
        
        self.getServiceEnabled = function(service) {
            return self.servicesEnabled[service] || false;
        };
        
        //Default services status
        self.setServiceEnabled(self.services.NATIVE_TTS, true);
        self.setServiceEnabled(self.services.FALLBACK_AUDIO, true);

        self.forceFallbackMode = function(value) {

            self.forcedFallbackMode = value;
            self.fallbackMode = value;
            self.mapRVs();

            self.Dispatch("OnServiceSwitched");
        }

        self.enableWindowClickHook = function() {

            self.userInteractionEvents.forEach(function(event) {
                    window.addEventListener(event, self.clickEvent, false);
            });


        }

        //Keep this at the end
        if(document.readyState === "interactive") {
            //Already loaded
            self.init();
        }else {
            document.addEventListener('DOMContentLoaded', function () {
                self.init();
            });
        }

    }
    var responsiveVoice = new ResponsiveVoice();
}
