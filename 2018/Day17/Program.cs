using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// This runs part 2. For part 1, remove comment on line 1667
// It's not perfect, I had to output the final map
// to a file and count up the water areas I missed and add it to the result.

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			string input = @"y=1160, x=336..349
y=1111, x=479..483
y=1369, x=409..419
x=413, y=698..701
x=450, y=953..962
y=528, x=427..432
y=678, x=532..545
y=663, x=380..386
x=511, y=595..623
x=460, y=1251..1263
y=670, x=380..386
y=702, x=453..473
x=340, y=1025..1040
x=343, y=1249..1266
x=455, y=1017..1039
y=1369, x=527..534
x=400, y=1219..1227
y=1565, x=336..341
x=358, y=245..257
y=845, x=447..451
x=398, y=1194..1208
x=429, y=1467..1480
y=544, x=384..386
x=445, y=1027..1052
y=232, x=521..524
y=1614, x=339..341
x=437, y=711..731
y=1377, x=343..356
y=1347, x=513..537
y=399, x=344..348
y=1601, x=373..435
x=480, y=647..660
x=350, y=89..94
y=7, x=438..458
y=1376, x=522..549
x=466, y=1406..1415
x=396, y=967..979
y=1215, x=519..530
x=368, y=1188..1195
x=356, y=506..514
x=479, y=993..1011
x=432, y=1383..1395
x=489, y=966..974
y=426, x=458..544
x=418, y=711..731
x=348, y=8..21
x=382, y=370..393
x=451, y=439..447
x=435, y=1596..1601
x=407, y=1059..1070
y=802, x=448..450
y=1364, x=350..361
y=1616, x=508..536
y=1532, x=539..545
x=397, y=658..678
x=387, y=66..89
x=493, y=1286..1289
y=1309, x=543..546
x=468, y=1235..1244
x=336, y=664..684
x=531, y=307..319
x=447, y=829..845
x=496, y=1527..1540
x=488, y=241..254
x=436, y=916..922
x=359, y=836..840
x=376, y=74..94
x=453, y=716..718
y=1183, x=452..467
y=62, x=520..522
x=479, y=1063..1071
x=502, y=1336..1344
y=1008, x=543..549
x=352, y=1546..1559
x=402, y=374..393
x=388, y=494..515
x=366, y=495..500
y=590, x=474..481
y=383, x=461..465
y=903, x=529..542
x=484, y=156..165
x=505, y=1337..1344
x=507, y=1255..1268
x=455, y=123..138
y=147, x=504..506
x=521, y=97..108
x=483, y=331..343
x=424, y=1363..1375
x=399, y=375..393
x=337, y=378..402
x=516, y=813..827
x=432, y=29..31
y=1266, x=343..367
y=837, x=463..472
x=537, y=1403..1420
x=532, y=968..970
y=684, x=336..342
x=375, y=1481..1490
y=518, x=458..476
y=629, x=428..436
x=502, y=286..296
x=546, y=1088..1093
x=458, y=506..518
x=424, y=335..351
x=440, y=773..784
x=493, y=869..874
x=463, y=967..974
y=806, x=538..543
y=954, x=334..360
y=254, x=485..488
x=379, y=842..864
x=537, y=969..970
y=1518, x=405..410
y=150, x=495..512
x=458, y=1209..1218
y=864, x=379..381
y=1324, x=430..434
x=505, y=887..893
y=602, x=523..534
y=494, x=438..464
x=435, y=39..54
x=531, y=1017..1043
x=441, y=1291..1302
x=476, y=1487..1499
x=452, y=174..179
y=750, x=488..511
x=466, y=1146..1158
x=361, y=408..426
y=1126, x=377..398
x=473, y=80..88
x=401, y=775..792
y=1165, x=381..402
x=410, y=781..784
x=435, y=1215..1231
x=367, y=625..643
x=486, y=1036..1046
x=485, y=1414..1439
x=544, y=157..162
y=1076, x=533..536
y=1241, x=456..459
y=1255, x=348..361
y=24, x=418..434
y=402, x=337..354
x=436, y=1293..1307
y=877, x=345..347
x=377, y=1036..1046
x=434, y=125..140
x=354, y=378..402
y=1462, x=523..550
x=438, y=481..494
x=447, y=290..300
x=388, y=943..955
y=1439, x=485..489
x=467, y=1171..1183
y=476, x=333..342
y=279, x=465..491
x=489, y=1350..1359
x=414, y=586..599
x=459, y=892..905
x=443, y=37..49
x=342, y=1026..1040
x=527, y=1369..1372
x=461, y=1149..1161
x=538, y=327..337
x=358, y=1114..1122
x=455, y=1408..1419
x=406, y=1412..1414
y=536, x=422..448
y=1395, x=410..432
y=782, x=491..493
y=1280, x=424..429
y=59, x=395..418
y=1359, x=476..489
x=419, y=774..792
x=536, y=532..556
x=492, y=807..810
x=453, y=287..297
x=545, y=443..451
x=406, y=1311..1333
x=421, y=1060..1070
x=544, y=1148..1162
x=522, y=74..88
y=1186, x=378..389
x=437, y=170..179
x=504, y=120..129
x=454, y=504..515
x=378, y=966..979
x=522, y=1101..1109
y=138, x=446..455
x=344, y=617..633
x=466, y=690..699
x=491, y=1153..1162
y=77, x=540..544
x=442, y=1318..1330
x=442, y=979..981
x=466, y=954..958
y=847, x=415..441
y=1520, x=353..355
x=353, y=190..213
y=1582, x=520..533
y=578, x=400..426
x=383, y=1384..1392
y=69, x=451..454
x=550, y=329..340
x=467, y=1506..1517
y=1536, x=486..489
x=446, y=1189..1198
y=438, x=333..353
y=1166, x=437..441
x=544, y=1022..1047
x=441, y=835..847
x=489, y=661..689
x=453, y=309..322
x=385, y=1362..1372
x=479, y=728..738
x=489, y=1534..1536
x=506, y=1496..1502
x=521, y=727..747
x=451, y=829..845
y=905, x=438..459
y=1071, x=479..501
x=468, y=1211..1223
x=369, y=1448..1459
x=448, y=312..325
y=213, x=346..353
y=1622, x=332..351
y=47, x=351..367
y=1052, x=442..445
y=379, x=474..479
x=498, y=117..126
x=497, y=197..211
y=1231, x=429..435
y=1372, x=527..534
x=385, y=1270..1293
x=333, y=131..151
y=737, x=386..412
x=360, y=1080..1094
y=147, x=344..346
x=454, y=51..69
x=414, y=1064..1067
x=494, y=1093..1112
x=418, y=1465..1473
x=501, y=1062..1071
x=386, y=730..737
x=375, y=631..636
y=264, x=402..413
y=1450, x=513..539
y=37, x=515..518
x=458, y=774..784
y=1039, x=455..472
y=902, x=415..417
y=1516, x=371..385
y=128, x=518..530
y=818, x=482..499
y=363, x=433..440
y=397, x=344..348
x=524, y=197..211
x=381, y=1270..1293
x=516, y=359..361
x=464, y=1428..1441
x=452, y=1192..1201
x=493, y=1210..1216
x=488, y=734..750
y=979, x=378..396
x=447, y=662..664
x=390, y=823..831
x=464, y=690..699
y=1158, x=466..471
x=421, y=1465..1473
x=387, y=1452..1456
x=407, y=973..983
y=438, x=360..385
x=534, y=1369..1372
x=394, y=945..958
y=1249, x=384..394
x=449, y=341..343
y=359, x=484..488
x=423, y=990..1000
x=344, y=397..399
x=389, y=1329..1336
x=464, y=481..494
x=464, y=64..68
x=337, y=616..633
x=342, y=339..342
x=476, y=1349..1359
y=1473, x=418..421
x=447, y=953..962
x=385, y=435..438
y=354, x=484..488
x=423, y=1319..1330
x=348, y=299..309
x=440, y=354..363
x=502, y=1579..1591
x=434, y=6..24
y=1079, x=522..545
y=1093, x=524..546
x=478, y=647..660
y=852, x=516..530
x=371, y=326..339
x=341, y=1170..1172
y=1280, x=466..481
y=512, x=446..448
x=385, y=1500..1516
y=1330, x=509..533
y=1198, x=441..446
y=557, x=498..508
x=543, y=327..337
x=382, y=749..766
x=457, y=442..453
x=515, y=29..37
x=426, y=1530..1543
y=296, x=497..502
x=442, y=1148..1151
x=487, y=596..623
x=544, y=1476..1497
y=742, x=495..500
y=880, x=511..521
y=94, x=341..350
x=449, y=439..447
x=516, y=838..852
y=976, x=385..389
x=543, y=134..145
x=500, y=1118..1130
x=488, y=946..951
x=492, y=610..618
x=518, y=1085..1095
x=426, y=1554..1565
x=400, y=84..86
y=757, x=447..460
x=450, y=1105..1116
x=458, y=570..589
x=461, y=366..383
x=378, y=1241..1255
y=296, x=345..354
x=342, y=1590..1604
y=69, x=357..372
x=495, y=158..168
x=398, y=1510..1522
y=68, x=464..485
y=190, x=485..509
y=427, x=434..437
x=492, y=999..1015
x=465, y=1541..1545
x=372, y=1240..1255
y=500, x=341..366
x=523, y=1456..1462
y=1497, x=540..544
y=101, x=511..513
x=473, y=335..337
y=1268, x=487..507
x=332, y=330..351
x=425, y=502..519
x=415, y=836..847
x=446, y=122..138
x=390, y=159..167
x=443, y=1345..1353
y=88, x=473..496
y=810, x=488..492
y=1195, x=340..368
y=1263, x=436..460
x=508, y=54..65
y=1151, x=421..442
x=455, y=309..322
x=383, y=136..144
y=1463, x=473..489
y=1454, x=340..345
x=342, y=1358..1361
y=558, x=540..550
x=348, y=1255..1260
x=518, y=123..128
x=359, y=149..176
y=867, x=461..472
x=537, y=140..142
x=419, y=1358..1369
x=393, y=693..704
y=755, x=447..460
y=1565, x=406..426
y=337, x=473..476
x=503, y=634..642
y=1430, x=503..508
x=526, y=993..1008
x=441, y=1189..1198
x=513, y=1427..1450
y=614, x=424..434
x=532, y=460..475
x=390, y=1309..1313
x=353, y=837..840
y=643, x=367..383
x=429, y=726..728
x=466, y=1106..1116
x=419, y=444..470
x=440, y=660..662
y=1201, x=433..452
x=395, y=823..831
x=513, y=94..101
x=364, y=949..966
x=462, y=94..109
x=402, y=797..816
y=919, x=498..500
y=1543, x=408..426
y=1223, x=452..468
y=345, x=411..416
x=409, y=158..167
x=489, y=1414..1439
x=389, y=1021..1023
x=463, y=214..222
x=533, y=481..487
x=450, y=1081..1094
x=540, y=1476..1497
x=367, y=79..97
x=532, y=222..235
x=461, y=1128..1137
x=344, y=145..147
x=373, y=631..636
x=416, y=805..820
x=483, y=527..539
y=1499, x=417..476
y=608, x=348..354
x=431, y=726..728
y=151, x=333..354
x=374, y=658..678
y=79, x=426..432
y=1179, x=459..461
x=476, y=215..222
y=945, x=416..437
x=441, y=1161..1166
x=469, y=373..386
y=1145, x=433..456
y=1307, x=436..452
x=443, y=660..662
x=395, y=21..26
y=97, x=355..367
x=368, y=1058..1070
x=451, y=51..69
y=1591, x=502..504
y=822, x=436..438
x=337, y=339..342
y=922, x=339..353
x=540, y=71..77
x=442, y=753..764
x=399, y=136..144
x=466, y=1258..1280
y=958, x=376..394
y=1427, x=359..365
x=341, y=89..94
x=519, y=754..755
y=1330, x=423..442
x=477, y=1178..1203
y=1368, x=431..434
x=516, y=72..85
x=448, y=791..802
y=998, x=397..399
y=1344, x=502..505
x=381, y=1139..1165
x=437, y=956..965
y=514, x=354..356
x=423, y=232..235
x=434, y=738..741
x=456, y=1232..1241
x=521, y=860..880
x=485, y=372..386
y=636, x=399..423
x=345, y=853..877
x=391, y=770..780
y=965, x=437..456
x=409, y=1357..1369
y=1513, x=472..478
y=179, x=449..452
y=1273, x=524..532
y=764, x=442..470
x=486, y=909..931
x=531, y=330..340
x=361, y=1547..1559
y=351, x=396..424
y=723, x=441..463
x=496, y=80..88
x=420, y=1034..1043
x=412, y=781..784
x=409, y=126..140
x=351, y=31..47
x=537, y=1340..1347
y=912, x=392..411
y=475, x=530..532
y=558, x=413..470
x=433, y=354..363
y=44, x=510..526
x=379, y=370..393
x=410, y=1193..1208
y=1534, x=370..373
x=439, y=738..741
x=413, y=244..264
x=355, y=80..97
x=472, y=1509..1513
x=370, y=949..966
y=1072, x=337..364
x=491, y=770..782
x=380, y=877..890
y=1346, x=398..403
x=487, y=1179..1203
y=1420, x=537..539
y=1021, x=389..403
x=341, y=654..660
x=542, y=397..410
y=1000, x=423..426
x=538, y=502..508
y=1517, x=467..486
x=353, y=908..922
x=417, y=1509..1522
x=471, y=629..641
x=354, y=339..356
x=380, y=663..670
x=417, y=736..752
x=412, y=1064..1067
x=334, y=1509..1530
y=781, x=410..412
x=412, y=1107..1113
x=467, y=311..325
x=456, y=955..965
x=355, y=1520..1527
x=480, y=790..791
x=512, y=140..150
x=341, y=977..991
x=395, y=750..766
y=719, x=370..373
y=1397, x=436..455
y=633, x=353..356
x=486, y=770..786
y=1116, x=450..466
x=344, y=654..660
y=1028, x=424..433
x=436, y=1383..1397
x=339, y=1614..1617
y=179, x=345..351
x=424, y=1230..1243
x=492, y=707..717
y=889, x=434..437
x=500, y=915..919
y=1018, x=356..366
y=642, x=503..508
x=472, y=815..837
y=1002, x=387..407
y=714, x=507..532
x=436, y=503..515
y=970, x=532..537
x=533, y=1562..1582
x=454, y=397..410
x=540, y=517..540
x=351, y=1611..1622
x=498, y=225..228
x=452, y=1212..1223
x=332, y=1611..1622
x=486, y=156..165
x=488, y=225..228
x=465, y=911..912
x=502, y=1383..1394
x=393, y=1329..1336
y=1015, x=483..492
x=486, y=1534..1536
x=469, y=1406..1415
y=85, x=514..516
x=456, y=1343..1356
y=575, x=340..351
y=232, x=482..509
y=733, x=471..473
x=387, y=576..582
x=511, y=735..750
x=373, y=714..719
x=485, y=65..68
x=432, y=377..393
y=1522, x=398..417
y=678, x=374..397
x=385, y=943..955
x=360, y=687..711
x=520, y=262..275
x=416, y=338..345
y=1545, x=463..465
y=1162, x=484..491
x=341, y=495..500
y=959, x=470..483
y=359, x=513..516
x=413, y=1468..1480
x=348, y=329..351
y=1137, x=435..461
y=1378, x=370..373
y=94, x=376..382
y=453, x=441..457
y=1478, x=380..406
y=785, x=520..523
x=470, y=943..959
y=343, x=445..449
x=539, y=1404..1420
x=514, y=72..85
y=515, x=436..454
x=508, y=635..642
x=488, y=354..359
x=509, y=219..232
y=193, x=389..398
x=515, y=993..1008
x=469, y=26..42
y=88, x=506..522
y=915, x=498..500
y=556, x=518..536
x=384, y=1247..1249
x=394, y=1247..1249
y=108, x=504..521
x=427, y=913..925
y=1094, x=360..450
x=458, y=424..426
y=1441, x=444..464
y=981, x=442..464
x=444, y=913..925
x=399, y=420..426
x=412, y=729..737
x=413, y=545..558
y=1110, x=455..458
y=86, x=396..400
x=487, y=628..641
y=1398, x=387..404
y=545, x=527..530
x=479, y=370..379
x=474, y=370..379
x=534, y=589..602
x=389, y=172..193
x=514, y=1556..1572
x=367, y=1034..1041
x=496, y=262..275
x=487, y=1551..1552
x=361, y=1352..1364
x=385, y=964..976
y=21, x=348..365
x=487, y=1255..1268
x=398, y=1119..1126
y=664, x=447..459
x=353, y=615..633
x=476, y=335..337
x=380, y=1468..1478
x=550, y=1456..1462
y=738, x=434..439
x=545, y=1058..1079
y=300, x=491..508
x=504, y=96..108
x=493, y=769..782
y=309, x=348..373
x=497, y=244..257
x=346, y=190..213
x=421, y=1148..1151
y=447, x=461..470
x=379, y=807..818
x=354, y=271..296
y=1484, x=506..531
x=416, y=935..945
x=506, y=1115..1125
x=366, y=994..1018
x=548, y=516..540
x=436, y=820..822
x=398, y=1345..1346
x=334, y=933..954
y=1305, x=519..536
y=1109, x=499..522
x=448, y=525..536
x=351, y=159..179
x=538, y=443..451
y=539, x=483..488
y=105, x=475..478
y=1456, x=385..387
y=974, x=463..489
x=336, y=1155..1160
x=539, y=1149..1162
y=1289, x=493..500
x=345, y=270..296
x=452, y=270..278
y=447, x=449..451
y=704, x=393..421
y=904, x=403..405
x=416, y=1551..1559
x=550, y=550..558
x=530, y=1199..1215
x=497, y=286..296
x=342, y=663..684
x=523, y=387..389
x=481, y=1036..1046
x=485, y=1570..1581
x=429, y=461..472
y=827, x=430..444
x=464, y=351..356
x=381, y=841..864
x=526, y=134..145
x=533, y=1311..1330
x=518, y=672..690
y=225, x=488..498
y=1203, x=477..487
x=339, y=908..922
y=786, x=479..486
y=1161, x=461..477
y=1040, x=340..342
x=354, y=130..151
y=807, x=438..456
x=337, y=1357..1361
y=389, x=508..523
y=1313, x=364..378
x=478, y=101..105
x=459, y=1176..1179
x=531, y=140..142
x=434, y=417..427
x=480, y=243..257
y=1352, x=410..431
y=109, x=462..484
y=1527, x=353..355
y=1125, x=506..514
x=387, y=10..13
y=1246, x=342..357
x=411, y=898..912
y=26, x=383..395
x=501, y=1555..1572
x=345, y=463..482
y=731, x=471..473
x=425, y=171..179
x=484, y=1152..1162
x=371, y=1500..1516
y=351, x=332..348
y=1493, x=367..386
x=476, y=505..518
y=144, x=383..399
x=539, y=1513..1532
y=113, x=373..400
x=471, y=352..362
y=1179, x=400..402
x=408, y=1531..1543
x=495, y=117..126
x=384, y=251..277
y=1414, x=404..406
x=465, y=365..383
x=424, y=1270..1280
x=465, y=289..300
x=506, y=946..951
x=392, y=575..582
y=410, x=454..542
x=483, y=1105..1111
x=448, y=501..512
y=738, x=462..479
y=474, x=480..502
y=925, x=427..444
y=235, x=512..532
y=791, x=459..480
x=506, y=143..147
x=435, y=1127..1137
x=456, y=287..297
x=463, y=1326..1337
y=1112, x=490..494
x=508, y=388..389
y=1026, x=377..415
x=367, y=1483..1493
y=662, x=440..443
x=365, y=1383..1392
x=450, y=791..802
x=452, y=771..781
y=890, x=380..400
x=382, y=297..320
y=257, x=480..497
x=514, y=1115..1125
x=460, y=755..757
x=453, y=570..589
x=402, y=1174..1179
x=459, y=789..791
y=1337, x=463..469
x=519, y=1298..1305
y=616, x=424..434
x=423, y=736..752
y=277, x=384..392
x=532, y=708..714
x=364, y=1307..1313
x=336, y=688..711
y=1604, x=342..497
y=1237, x=415..418
x=546, y=1023..1047
x=422, y=294..314
y=155, x=464..472
x=417, y=1487..1499
x=353, y=436..438
y=1043, x=420..423
y=38, x=357..361
x=523, y=759..785
x=459, y=1232..1241
y=314, x=402..422
x=453, y=692..702
x=462, y=330..343
x=358, y=1171..1172
x=378, y=1176..1186
x=530, y=123..128
y=690, x=504..518
y=337, x=538..543
x=535, y=156..162
x=444, y=817..827
x=508, y=909..931
x=361, y=111..122
x=396, y=336..351
x=455, y=670..684
x=477, y=1148..1161
x=433, y=1491..1495
x=503, y=978..999
x=387, y=1379..1398
x=387, y=990..1002
x=432, y=63..79
y=820, x=416..426
y=49, x=440..443
x=504, y=671..690
x=513, y=1339..1347
x=509, y=1312..1330
x=471, y=1146..1158
x=360, y=436..438
x=333, y=436..438
x=433, y=1017..1028
x=384, y=793..796
x=382, y=5..16
x=471, y=731..733
y=472, x=506..509
x=391, y=1489..1504
x=368, y=661..671
x=481, y=573..590
x=402, y=1139..1165
y=519, x=404..425
y=1023, x=389..403
y=1356, x=456..461
y=129, x=487..504
x=385, y=875..887
y=126, x=495..498
y=224, x=403..428
x=479, y=1105..1111
y=1572, x=501..514
x=417, y=879..902
x=357, y=36..38
x=437, y=1161..1166
x=384, y=529..544
x=357, y=65..69
x=476, y=1528..1540
x=436, y=627..629
x=482, y=219..232
x=415, y=1013..1026
x=428, y=200..224
x=456, y=1143..1145
x=438, y=820..822
x=459, y=233..255
x=524, y=227..232
y=610, x=492..498
y=430, x=443..552
x=370, y=1034..1041
x=502, y=469..474
x=464, y=152..155
x=437, y=1346..1353
x=536, y=1298..1305
x=472, y=1016..1039
y=1216, x=478..493
y=1504, x=391..393
x=533, y=264..266
x=491, y=289..300
x=405, y=901..904
x=507, y=709..714
x=480, y=1495..1502
y=1250, x=511..538
x=397, y=4..16
x=423, y=40..54
y=168, x=478..495
y=1540, x=476..496
x=481, y=1258..1280
x=385, y=1218..1227
y=297, x=453..456
x=465, y=268..279
y=1218, x=458..462
y=320, x=382..385
x=437, y=936..945
y=1473, x=335..354
x=433, y=916..922
y=731, x=418..437
x=370, y=1351..1378
y=1361, x=337..342
y=342, x=337..342
y=257, x=334..358
x=455, y=1103..1110
y=1172, x=341..358
y=741, x=434..439
y=20, x=490..510
y=530, x=427..432
x=508, y=1594..1616
x=380, y=1429..1439
x=447, y=29..31
x=529, y=885..903
x=520, y=1562..1582
x=545, y=659..678
y=582, x=387..392
x=461, y=848..867
y=476, x=459..464
x=386, y=530..544
x=473, y=693..702
x=508, y=288..300
y=140, x=409..434
y=179, x=425..437
y=1302, x=441..446
x=528, y=55..65
x=356, y=1367..1377
y=487, x=521..533
x=540, y=551..558
x=442, y=1026..1052
x=511, y=94..101
x=356, y=1570..1581
y=241, x=363..372
x=435, y=1037..1050
y=815, x=363..367
y=515, x=388..390
y=1195, x=527..535
x=478, y=1509..1513
x=438, y=793..807
x=473, y=1444..1463
x=441, y=714..723
x=457, y=352..356
y=1448, x=544..550
x=365, y=1408..1427
x=365, y=464..482
y=1244, x=450..468
x=439, y=376..393
y=841, x=420..431
x=488, y=526..539
x=506, y=75..88
x=368, y=759..760
y=1460, x=429..456
x=400, y=878..890
x=348, y=1342..1347
y=818, x=356..379
y=1552, x=487..492
y=145, x=526..543
x=346, y=145..147
y=1375, x=424..445
x=386, y=1484..1493
y=866, x=436..457
x=363, y=215..241
y=1008, x=515..526
x=414, y=1551..1559
y=393, x=379..382
y=1050, x=415..435
x=332, y=822..829
x=369, y=153..169
x=389, y=1176..1186
x=475, y=1409..1419
x=418, y=1273..1283
x=539, y=291..312
x=485, y=178..190
x=546, y=1297..1309
x=334, y=246..257
x=440, y=37..49
x=543, y=991..1008
x=484, y=1117..1130
y=689, x=489..491
x=420, y=232..235
x=462, y=1209..1218
x=438, y=893..905
x=391, y=875..887
x=399, y=610..620
x=504, y=349..365
y=784, x=440..458
x=448, y=771..781
x=500, y=742..747
x=436, y=1272..1283
x=538, y=1210..1223
x=521, y=480..487
y=1283, x=418..436
x=409, y=1230..1243
y=641, x=471..487
y=169, x=369..374
y=176, x=359..384
y=1480, x=413..429
y=1073, x=533..536
x=354, y=506..514
x=391, y=1549..1554
y=874, x=490..493
y=42, x=469..479
x=393, y=1448..1459
x=365, y=7..21
x=400, y=565..578
x=504, y=143..147
x=472, y=848..867
x=410, y=444..470
x=533, y=1073..1076
y=935, x=373..392
x=341, y=1614..1617
x=345, y=158..179
x=333, y=456..476
x=487, y=119..129
x=403, y=199..224
x=474, y=572..590
x=433, y=1144..1145
x=479, y=526..528
x=431, y=1368..1371
x=470, y=545..558
x=498, y=610..618
y=962, x=447..450
y=1559, x=414..416
y=661, x=420..435
y=631, x=373..375
x=508, y=544..557
x=382, y=75..94
y=663, x=469..486
x=491, y=662..689
x=387, y=1209..1212
x=378, y=1306..1313
x=429, y=734..744
x=399, y=996..998
x=434, y=881..889
y=255, x=447..459
x=393, y=1489..1504
x=489, y=1444..1463
x=347, y=853..877
x=457, y=853..866
y=16, x=382..397
x=470, y=873..883
x=510, y=1016..1043
x=464, y=980..981
x=397, y=996..998
x=483, y=944..959
x=490, y=10..20
y=1389, x=462..466
y=142, x=531..537
x=538, y=1234..1250
y=887, x=385..391
x=417, y=1406..1418
x=431, y=1342..1352
x=381, y=326..339
x=519, y=1199..1215
x=345, y=1437..1454
x=509, y=464..472
x=391, y=1057..1070
y=1412, x=404..406
x=509, y=178..190
x=362, y=339..356
x=374, y=153..169
y=230, x=383..391
y=1581, x=356..485
x=421, y=692..704
y=618, x=492..498
x=504, y=1578..1591
x=452, y=1172..1183
x=544, y=1435..1448
x=422, y=525..536
x=456, y=716..718
x=336, y=1540..1565
y=1070, x=407..421
y=542, x=527..530
x=436, y=852..866
y=1212, x=387..389
y=728, x=429..431
x=499, y=798..818
x=498, y=915..919
x=530, y=460..475
y=65, x=508..528
y=1394, x=502..510
y=820, x=436..438
x=495, y=141..150
x=396, y=1308..1313
y=958, x=463..466
y=1313, x=390..396
x=472, y=152..155
x=438, y=586..599
x=405, y=475..499
x=510, y=1383..1394
x=354, y=1469..1473
x=359, y=1407..1427
y=325, x=448..467
x=446, y=501..512
x=506, y=463..472
x=430, y=1324..1327
y=831, x=390..395
x=403, y=1344..1346
x=491, y=268..279
x=506, y=1473..1484
x=377, y=1119..1126
y=931, x=486..508
x=360, y=933..954
x=497, y=1590..1604
y=278, x=452..455
x=361, y=36..38
x=406, y=1469..1478
x=526, y=31..44
y=1495, x=433..454
x=363, y=976..991
x=488, y=807..810
y=1554, x=382..391
y=1255, x=372..378
y=1046, x=481..486
y=1419, x=455..475
x=490, y=870..874
x=407, y=698..701
x=404, y=502..519
x=527, y=1173..1195
x=523, y=588..602
x=458, y=4..7
y=472, x=429..451
x=499, y=1100..1109
y=1095, x=508..518
x=480, y=670..684
x=400, y=1174..1179
y=955, x=385..388
x=549, y=1356..1376
x=504, y=814..827
x=475, y=101..105
x=451, y=874..883
x=356, y=661..671
x=365, y=770..780
x=410, y=1341..1352
x=428, y=628..629
x=481, y=910..912
x=357, y=1241..1246
x=484, y=354..359
x=510, y=32..44
x=427, y=528..530
y=760, x=346..368
y=747, x=521..525
y=1227, x=385..400
y=1190, x=394..409
x=530, y=542..545
x=486, y=1507..1517
y=1327, x=430..434
y=1530, x=334..361
x=479, y=769..786
x=376, y=946..958
x=536, y=1073..1076
y=340, x=531..550
y=747, x=495..500
x=541, y=94..117
x=495, y=742..747
x=486, y=650..663
x=415, y=879..902
y=319, x=477..531
x=540, y=1210..1223
x=423, y=1034..1043
y=1240, x=415..418
x=376, y=419..426
x=373, y=1522..1534
x=498, y=543..557
x=466, y=1377..1389
y=1392, x=365..383
x=462, y=1377..1389
y=222, x=463..476
x=409, y=1170..1190
y=1070, x=368..391
x=535, y=1173..1195
x=348, y=519..537
y=951, x=488..506
y=684, x=455..480
y=623, x=487..511
y=228, x=488..498
y=1243, x=409..424
y=699, x=464..466
x=532, y=753..755
x=415, y=1036..1050
y=792, x=401..419
x=377, y=1013..1026
y=1122, x=337..358
y=784, x=410..412
x=366, y=794..796
y=13, x=387..389
y=1047, x=544..546
x=386, y=663..670
x=337, y=1114..1122
y=867, x=400..426
x=544, y=72..77
x=438, y=4..7
x=512, y=979..999
x=389, y=10..13
x=527, y=542..545
x=404, y=1412..1414
x=455, y=1384..1397
x=346, y=112..122
x=361, y=1255..1260
y=1415, x=466..469
x=497, y=351..362
x=426, y=989..1000
x=389, y=964..976
x=411, y=1310..1333
x=426, y=64..79
x=458, y=1103..1110
y=930, x=381..385
x=424, y=1018..1028
x=548, y=265..266
x=349, y=1156..1160
y=1156, x=354..374
y=470, x=410..419
y=701, x=407..413
y=528, x=469..479
x=545, y=292..312
y=912, x=465..481
y=339, x=371..381
x=525, y=728..747
x=385, y=1452..1456
x=543, y=781..806
y=426, x=376..399
x=418, y=38..59
x=451, y=461..472
x=512, y=223..235
x=449, y=174..179
x=447, y=755..757
y=991, x=341..363
x=394, y=1170..1190
x=406, y=1429..1439
x=370, y=1522..1534
x=511, y=860..880
x=381, y=919..930
x=402, y=243..264
y=827, x=504..516
y=711, x=336..360
y=300, x=447..465
x=434, y=614..616
x=356, y=807..818
y=343, x=462..483
y=482, x=345..365
x=410, y=796..816
x=363, y=813..815
x=406, y=1553..1565
x=405, y=1507..1518
y=312, x=539..545
x=462, y=729..738
y=1130, x=484..500
y=1043, x=510..531
y=766, x=382..395
x=389, y=1209..1212
x=352, y=823..829
x=432, y=528..530
x=337, y=1068..1072
y=322, x=453..455
y=780, x=365..391
x=538, y=780..806
x=400, y=858..867
x=459, y=470..476
x=469, y=649..663
x=343, y=1367..1377
x=456, y=1448..1460
x=518, y=532..556
x=356, y=994..1018
y=1559, x=352..361
x=367, y=31..47
x=350, y=1352..1364
y=840, x=353..359
y=1113, x=384..412
x=461, y=436..447
x=351, y=560..575
y=393, x=399..402
y=1372, x=385..389
y=508, x=531..538
y=698, x=407..413
y=999, x=503..512
x=450, y=1234..1244
y=1347, x=348..372
x=382, y=1548..1554
x=550, y=1436..1448
y=983, x=407..409
x=437, y=882..889
y=117, x=534..541
x=459, y=663..664
x=543, y=1298..1309
y=1371, x=431..434
x=383, y=22..26
y=1293, x=381..385
x=508, y=1086..1095
y=235, x=420..423
y=266, x=533..548
x=389, y=1361..1372
x=403, y=901..904
x=520, y=760..785
y=1046, x=361..377
x=433, y=1191..1201
y=1162, x=539..544
y=620, x=399..479
y=966, x=364..370
x=446, y=1291..1302
x=431, y=839..841
x=530, y=839..852
x=383, y=626..643
x=447, y=233..255
x=536, y=1595..1616
x=549, y=991..1008
x=354, y=596..608
x=480, y=470..474
x=395, y=1406..1418
x=463, y=815..837
x=510, y=11..20
y=1502, x=480..506
x=478, y=1209..1216
x=436, y=1252..1263
x=409, y=972..983
y=1260, x=348..361
y=361, x=513..516
x=408, y=65..89
x=503, y=1408..1430
x=444, y=1428..1441
x=410, y=1507..1518
x=532, y=659..678
x=508, y=1407..1430
y=537, x=340..348
x=341, y=1540..1565
x=377, y=1481..1490
x=342, y=455..476
x=340, y=561..575
y=365, x=504..527
y=1011, x=464..479
x=348, y=397..399
x=424, y=614..616
x=420, y=839..841
y=922, x=433..436
x=524, y=1087..1093
x=411, y=338..345
x=374, y=1133..1156
x=335, y=1468..1473
x=402, y=295..314
y=1418, x=395..417
y=744, x=429..453
x=534, y=95..117
x=479, y=611..620
y=1208, x=398..410
y=636, x=373..375
x=373, y=921..935
y=356, x=457..464
y=893, x=500..505
x=372, y=64..69
y=54, x=423..435
x=384, y=150..176
x=464, y=993..1011
y=633, x=337..344
y=1336, x=389..393
x=410, y=1383..1395
x=372, y=1341..1347
x=463, y=955..958
y=499, x=405..414
x=483, y=999..1015
x=346, y=758..760
x=500, y=1285..1289
y=718, x=453..456
y=167, x=390..409
x=373, y=104..113
y=199, x=374..380
x=418, y=1237..1240
x=453, y=735..744
x=469, y=527..528
x=478, y=159..168
x=426, y=804..820
x=461, y=1176..1179
y=883, x=451..470
y=451, x=538..545
x=370, y=713..719
x=392, y=899..912
x=392, y=252..277
x=522, y=1356..1376
x=354, y=1132..1156
x=340, y=519..537
x=367, y=813..815
y=356, x=354..362
y=89, x=387..408
y=1353, x=437..443
x=403, y=1021..1023
y=1041, x=367..370
x=367, y=1249..1266
x=522, y=1059..1079
x=464, y=471..476
x=423, y=625..636
x=400, y=105..113
y=362, x=471..497
x=492, y=1550..1552
x=531, y=1474..1484
x=383, y=204..230
x=531, y=503..508
x=392, y=922..935
x=435, y=658..661
y=1459, x=369..393
y=386, x=469..485
x=391, y=204..230
x=437, y=416..427
x=364, y=1068..1072
y=789, x=427..431
y=1067, x=412..414
x=524, y=1260..1273
x=414, y=476..499
x=521, y=227..232
y=1617, x=339..341
y=393, x=432..439
y=540, x=540..548
x=342, y=1240..1246
x=473, y=731..733
x=385, y=919..930
x=504, y=205..208
x=445, y=340..343
y=671, x=356..368
x=520, y=52..62
y=31, x=432..447
x=407, y=990..1002
y=816, x=402..410
x=471, y=708..717
x=544, y=424..426
x=513, y=359..361
x=404, y=1380..1398
x=339, y=408..426
y=755, x=519..532
x=398, y=171..193
x=430, y=817..827
x=395, y=37..59
y=589, x=453..458
x=452, y=1294..1307
y=796, x=366..384
x=373, y=299..309
y=660, x=341..344
x=511, y=205..208
y=1223, x=538..540
x=429, y=1214..1231
x=479, y=25..42
x=482, y=799..818
x=455, y=269..278
x=385, y=298..320
x=532, y=1260..1273
x=361, y=1510..1530
x=470, y=752..764
x=429, y=1270..1280
x=441, y=441..453
x=356, y=614..633
x=353, y=1520..1527
y=426, x=339..361
x=373, y=1350..1378
y=1490, x=375..377
x=470, y=437..447
x=443, y=420..430
x=396, y=84..86
y=208, x=504..511
x=545, y=1514..1532
x=429, y=1449..1460
x=454, y=1491..1495
y=275, x=496..520
x=500, y=887..893
x=426, y=566..578
y=752, x=417..423
x=415, y=1237..1240
x=427, y=770..789
x=518, y=29..37
y=165, x=484..486
x=348, y=597..608
x=463, y=1542..1545
y=839, x=420..431
x=426, y=857..867
y=660, x=478..480
y=211, x=497..524
x=372, y=214..241
x=552, y=419..430
x=522, y=52..62
y=1333, x=406..411
x=434, y=1324..1327
x=542, y=886..903
x=477, y=307..319
x=340, y=1438..1454
x=361, y=1037..1046
y=717, x=471..492
y=829, x=332..352
y=1439, x=380..406
x=384, y=1107..1113
x=445, y=1363..1375
x=431, y=769..789
x=490, y=1093..1112
x=527, y=349..365
x=463, y=713..723
x=340, y=1188..1195
x=373, y=1596..1601
x=390, y=493..515
x=539, y=1426..1450
x=420, y=658..661
y=781, x=448..452
y=122, x=346..361
x=399, y=626..636
x=511, y=1234..1250
x=434, y=1368..1371
y=162, x=535..544
x=380, y=186..199
x=461, y=1343..1356
x=374, y=187..199
y=599, x=414..438
x=456, y=794..807
x=469, y=1325..1337
x=484, y=93..109
x=418, y=7..24
x=485, y=241..254";
			int xsize = 2000;
			int ysize = 2000;
			int springx = 500;
			int springy = 0;
			int minY = int.MaxValue;
			int maxY = int.MinValue;
			char[,] slice = new char[xsize, ysize];
			for (int x = 0; x < xsize; x++)
			{
				for (int y = 0; y < ysize; y++)
				{
					slice[x, y] = '.';
				}
			}
			string[] lines = input.Split('\n');
			foreach (string line in lines)
			{
				string[] parts = line.Split(',');
				string rowOrColPart = parts[0].Trim();
				string rangePart = parts[1].Trim();

				string[] rowOrColSplits = rowOrColPart.Split('=');
				string xOrY = rowOrColSplits[0];
				int rowOrCol = int.Parse(rowOrColSplits[1]);

				string[] rangeSplits = rangePart.Split('=')[1].Split('.');
				int rangeMin = int.Parse(rangeSplits[0]);
				int rangeMax = int.Parse(rangeSplits[2]);

				for (int i = rangeMin; i <= rangeMax; i++)
				{
					if (xOrY == "x")
					{
						slice[rowOrCol, i] = '#';
						if (i < minY)
						{
							minY = i;
						}
						if (i > maxY)
						{
							maxY = i;
						}
					}
					else
					{
						//assuming it's y
						slice[i, rowOrCol] = '#';
					}
				}


			}

			Queue<Point> springs = new Queue<Point>();
			springs.Enqueue(new Point(springx, springy));
			while (springs.Count() > 0)
			{
				Point spring = springs.Dequeue();
				Point current = new Point(spring);
				bool brokeWhile = false;
				//go down until we find a floor
				while (slice[current.x, current.y + 1] != '#')
				{
					slice[current.x, current.y + 1] = '|';
					current.y++;
					if (current.y > maxY)
					{
						brokeWhile = true;
						break;
					}
				}
				if (brokeWhile)
				{
					continue;
				}
				int floorRight = int.MinValue;
				int floorLeft = int.MaxValue;
				int xVal = current.x;
				while (slice[xVal, current.y + 1] == '#')
				{
					floorRight = xVal;
					xVal++;
				}

				xVal = current.x;
				while (slice[xVal, current.y + 1] == '#')
				{
					floorLeft = xVal;
					xVal--;
				}

				bool overflow = false;
				while (!overflow)
				{
					// fill the container and work up until we overflow
					int leftWall = -1;
					int rightWall = -1;
					for (int x = current.x; x >= floorLeft; x--)
					{
						if (slice[x, current.y] == '#')
						{
							leftWall = x;
							break;
						}
					}
					for (int x = current.x; x <= floorRight; x++)
					{
						if (slice[x, current.y] == '#')
						{
							rightWall = x;
							break;
						}
					}
					if (leftWall != -1 && rightWall != -1)
					{
						for (int i = leftWall + 1; i < rightWall; i++)
						{
							slice[i, current.y] = '~';
						}
					}
					else
					{
						overflow = true;
						// look left for new spring
						xVal = current.x;
						while (slice[xVal, current.y] != '#')
						{
							slice[xVal, current.y] = '|';
							//if nothing under it queue it and we are done
							if (slice[xVal, current.y + 1] == '.')
							{
								springs.Enqueue(new Point(xVal, current.y));
								break;
							}
							// already falling
							else if (slice[xVal, current.y + 1] == '|')
							{
								break;
							}
							xVal--;
						}
						xVal = current.x;
						while (slice[xVal, current.y] != '#')
						{
							slice[xVal, current.y] = '|';
							//if nothing under it queue it and we are done
							if (slice[xVal, current.y + 1] == '.')
							{
								springs.Enqueue(new Point(xVal, current.y));
								break;
							}
							// already falling
							else if (slice[xVal, current.y + 1] == '|')
							{
								break;
							}
							xVal++;
						}
					}
					current.y--;
				}

			}
			int total = 0;
			for (int y = minY; y <= maxY; y++)
			{
				for (int x = 0; x < xsize; x++)
				{
					if (slice[x, y] == '~') //|| slice[x, y] == '|')
					{
						total++;
					}
				}
			}
			Console.WriteLine(total);
			slice[500, 0] = '+';
			string[] txtlines = new string[2000];
			for (int y = 0; y < ysize; y++)
			{
				string line = "";
				for (int x = 0; x < xsize; x++)
				{
					line += (char)slice[x, y];
				}
				txtlines[y] = line;
			}
			System.IO.File.WriteAllLines(@"C:\temp\Day17-1.txt", txtlines);
			Console.ReadLine();

		}
	}
	public class Point
	{
		public int x;
		public int y;

		public Point(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
		public Point(Point p)
		{
			this.x = p.x;
			this.y = p.y;
		}
	}
}
