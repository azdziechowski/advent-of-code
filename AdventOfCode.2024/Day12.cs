using System.Diagnostics;

namespace AdventOfCode._2024;

[TestFixture]
public class Day12
{
    private const string TestInput1 =
        """
        AAAA
        BBCD
        BBCC
        EEEC
        """;
    
    private const string TestInput2 =
        """
        RRRRIICCFF
        RRRRIICCCF
        VVRRRCCFFF
        VVRCCCJFFF
        VVVVCJJCFE
        VVIVCCJJEE
        VVIIICJJEE
        MIIIIIJJEE
        MIIISIJEEE
        MMMISSJEEE
        """;

    private const string TestInput3 =
        """
        OOOOO
        OXOXO
        OOOOO
        OXOXO
        OOOOO
        """; 

    private const string TestInput4 =
        """
        EEEEE
        EXXXX
        EEEEE
        EXXXX
        EEEEE
        """; 
        
    private const string TestInput5 =
        """
        AAAAAA
        AAABBA
        AAABBA
        ABBAAA
        ABBAAA
        AAAAAA
        """; 


    private const string Input =
        """
        YYYYYMMMMMMUUUUUUUUNNNNUTTTTTAASAXXXXXHHEEHHEEEEERYYYYYYYYYYHHHHHHHHHHHHHHHHFFFFFFFFFFAAAAAAAAAAAAAOOOOOOOOYYYYYYYYYYYYYYYYVVVVWWWWWWWZZZZZZ
        YYYYYMMMMMMUMUUUUUUUUUUUTTAAALAAAAXXXHHFHHHEEEEEERRRRYYYYYYQHHHHHHHHHHHHHHHHHFFFFFFFFFAAAAAAMMMMMMMMMMMOOOOOYYYYYYYYYYYYYYYVVVWWWWWWKWZZZZZZ
        YYYYYMMMMMMMMMMUUUUUUUUUTAAAAAAAAXXXXHHHHHHEEEEEERRRYYRYYYYQQHHHHHHHHHHHHHHHHFFFFFFAAAAAAAAAMMMMFMMMMOOOOOOOYYYYYYYYYYYYYYVVVVWWWTWKKWZKKZZZ
        YYYYYYMMMMMMMUUUUUUUUUUUUAAAAAAAAHHHHHHHHHHHEEERRRRRYYRQQQQQQHHHHHHHHHHHHHHHHFFFFFAAAAAAAAAAAMMMMMMMMOOOOOOOYYYYYYYYYYYNDDDDDDTTTTTKKKKKKZZZ
        YYYYMMMMMMMMMUUUUUUUUUUUUAAAAAAAAHHHHHHHHHHHMEERRRRRRRRRQQQQQQQHHHHHHHHHHHHHFFFFFFAAAAAAAAAAAMMMMMMMMOOOOOOOOYYYYYYYYYYNDDDDDDDDTTKKKKKKKKKK
        YYYMMMMMMMMMMMMUUUUUUUUUUAAAAAAAAHHHHHHHHHKHMEERRRRRRRRQQQQQQQQQHHHHHHHHHHHHHFFFFFFFAAAAAAMMMMMMMMMMMOOOOOOOYYKYYYYYYYYNNDDDDDDTTKKKKKKKKKKM
        YYYYMMMMMMMMMMMUUUUUUAUUUAAAAAAAHHHHHHHHMMMMMEERRIRRRQQQQQQQQQQQIHHHHHHHHHHHHHFFTTTFAVVAUUUUMMMMMMMMMMOOOOOOOYYYYYCYYDDDDDDDDDDTTTTTKKKKKKKM
        YYYMMMMMMMMMMMMMUPPUUAAAAAAAAAAAAHHYYLQQMMMMMEEIIIRRRRQQQQQQQQQQHHHHHHHHHHLLHFFTTTTTRRVVVVUUMMMMMMMMMMMOOOOOOYYYYYFFVVDDDDDDDDDKKKKKKKKKKKKK
        YYYMMMMMMMMMMMMMUPPPAAAAAAAAAABBAHHHHLQLLMLLMEIIIIIIRRQQQQQQQQQQQXHHHHHHHHKLHFFTTTTTRRVVVVVUMMMMMMMMPOOOOOOOYYYFYFFFFFFDDDDDDDDDKKKKKKKKKKKK
        YYYYMMMMMMMMMMOOUPPPPPNNAAAAABBOHHHHHLLLLLLLLIIIIIINIRRQQQQQQQQQQXHHHHHHHHKKHFFOOTTVVVVVVVVMMMMMMMMMPOOOOOOOOOFFFFFFFFFDDDDDDDDDWWKKKKKKKKKK
        YYYYYMMMMMMMMMMUUPPPPNNNAAABBBBOHHHHLLLLLLLLIIIIIIIIIRQQQQQQQQQQQXXHHHHHHHKKHFFKOTTVVVVVVVVVOMMMMMZMPOOOOOOOOOFFFFFFFFFFDDDDDDDDDWWKKKKKKKKK
        YEEMMMMMMMZMMMRRRPPNNNNNNAABBBBOOHHLLLLLLLLLLLIIIAIIIRRRQRQQQQQQQQXXHHHKCHKKKKKKOOOVVVVVVVVVVSMMMMMSOOOOOOOOOOFFFFFFFFFDDDDDDDDDWKKKKKKKKKKK
        EYEEMMMMMMMMMMRNNPNNNNNNAAAABBBOOLLLLLLLLLLLLIIIIIIIRRRRRRRRQQSQCSXXXXXKKKKKKKKKOOOVVVVVVSVVVSMMMMSSSOOOOOOOOOFFFFFFFFFFDDDDDDDDWKKKKKKKKWKK
        EEEEEQMMMMMGMRRTNNNNNNNNAAAAPAJAALLLLLLLLLLLLIIIIIIIRRRRRRRRQSSSSSSXXKKKKKKKKKKKKVVVVVVVRSVVSSMMSSSSSOOOOOOOCCFFFFFFFFFFDDDDDDDDWWKWWWWWKWWW
        EEEEEEEMNNMGTTTTTNNNNNNNAAAAAAAAALLLLLLLLLLLLIIIIIIIIRRRRRRRRSSSSSSXXKKKKKKKKKZZVVVVVVVVRSSSSSSSSSSSLOOOOLLOOLZFFFFFFFFFFFFDDDDDWWWWWWWWWWWW
        EEEEEEEMMEGGTTTTNNNNNNNWNAAAAAAJALLLLLLLLLLLIIIIIIIIBZZZZRRRSSSSSSSSSKKKKKKKKKZZZVVVVVRRRRRSSSSSSSLLLOLLLLLLLLPFFFFFFPFPFFDDDDDDDWWWWWWWWWWW
        EEEEEEEEEEEEVTTTNNNNNNNNNAAAAAAAPLLLWLLWWLLLLIIIIIIIBZZZZRRSSSSSSSSSAKKKKKKKKKZZZZVVVRRRRRRSSSSSSLLLLLLLLLLLLPPFFFFPPPPPFDDDDDDDDVWWWWWWWWWW
        EEEEEEEEEEEEETTTTTNNNNNNNAAAAAPPPPPLWWWWWLLLLLLZIIIBBBZZZZRSSSSSSSSSSKKKKKKKZZZZZZZVVRRVRRRRSSTSSLSLLLLLLLLLLLPPPPPPPPPPPDDDDDDDVVWWWWWWWWWW
        EEEEEEEEEEEEEEETTTNNNNNNNAAAAPPPPPPPPWWTWLLLLLLZZIIBBBZZZRRRSSSSSSWSKKKKKZZKZZZZZZZZZTRRRRRRTSTTSSSNNLLLLLLLLPPPPPBPPPPVDDDDDDDDDVVVWWWWWWWW
        EEEEENEEEEEEEEETTNNNNNNNNAAAAPPPPPPPPWAWWLLWLLZZZZIZZZZZZZRRSSSSSSSHHKKKKKZZZZZZZZZZZTTRRRRRTTTSSSSNNNNLLLLLLPPPPPPPPPBVVVDDDDDVVVVVWWWWWWWW
        EEEENNNEEEEEEEENNNNNNNNNNAGGDGGGGPPPPWWWWWWWLLZZZZZZZZZZZZRRSSSSSSSHHKKKKKQZZZZZZZZZZTTTTRRTTTTTSSSNNNNLLLLLLLLPPPPPPPVVVVVDDVDVVVVVWWWWWWWW
        EEEENNNNNNEEPPEPNNNNNNNMGGGGDDGGGGPPPWWWWWWWWWZZZZZZZZZZZZRRSSSSSSSHKKKKNNNPPZZZZZZZTTTTRRRTTTNNSNSNNNNLNLLLLLLPPPPPPPPVVVVVVVVVVVVWWWWWWWWW
        EEEENNNNNNNNPPPPNNNNNNNMGGGGGGGGGWWPPPWWWWWWWZZZZZZZZZZZZZZRRRSSSSSHHHHHHNNNZZZZZZZZTTTTTTTTNNNNNNNNNNNNNNLLLLPPPPPPEPEVVVVVVVVVVVVVWWWWWWWW
        EEENNNNNHNNNPNNNNNNNNNNNNGGWGGGGGGWWWWWWWWWWWZZZZZZZZZZZZZZRSSSSSSSSHHHHHNNNNNZZZZZTTTTTTTTTTNNNNNNNNNNNNNLLLLPPPPPPEPEEEVVEVVVVVVVVWWWWWUUW
        ENNNNNNNNNNNNNJJNVVVVVNENGGGGGGGGGWWWWWWWWWSSRZRZZZZZZZZZZZZSSSSSSSHHHHQHHNNNZZZTTTTTTTTTTTTTNNNNNNNNNNNNNNNNLPPPPPPEEEEEEEEEEVVVVVWWVWWWUWW
        NDNNNNNNNNNNNNGGGVVVVNNVVGGGGGGGGGWWWWWWWWWWSRRRZZZZZZZZZZZZZSSSSSQHHHQQQQNNNNZTTTTTTTTTTTTTNNNNNNNNNNNNNNNNLLLLPPEEEEEEEEEEEEVVVVVVVVWWWUUU
        NNNNNNNNNNNNGGGGGGVVVVVVGGGGSGBBGGGWWWWWWWRRRRRNNNZZZZZZZZZZZQQQSQQQHQQQQNNNNNTTTTTTTTTTTTNTNNNNNNNNNNNNNKLLLLLLPPEKEEEEEEEEEEEEVVVVVWWWWWWU
        NNNNNNNNNNNNGGGGGGGGVVVVGGGGBBBBGGGGGWWWWVRRRRRRRNZZZZZZZZZZZQQQSQQQQQQQQNNNNNTTTTTTTTTTTTNNNNNNNNNNNNNNNKLLLLLKKKKKEEEEEEEEEEEEVVVVVWWWWWUU
        NNNNNNNNNNNNNGGGGGGGVVVGGBBBBBBBGGGGGGWWWRRRRRRRRRZZZZZZZZZZZQQQQQQQQQQQNNNNNNNTTTTTTTTTTTYNNNNNNNNNNNNYYKKKLLLKKKKKKKEEEEEEMMMMVVVMWWWWWWUW
        NNNNNNNNNNNNNZGGGGGVVVGGGGGGGGBGGGGGGOOWXRRRRRRRRRLZWWHZKZRZQQQQQQQQQQQQNNOOONTTTOBBTTTTTTTBBBNNNNNNNNNYYYKKKKKKKKKKKKEKEFEMMMMMZMMMWWWWWWUW
        NNNNNNNNNNNNZZZZZJJJJGGGGGGGGGGGGGGGGOOOXRRRRRRRRRRWWWWWWRRZQQQQQQQQQQQQQNNOONMTOOBBBTTCTCTBBBNNNNNNYYNYYYYYKKKFKFFKKKEKEMMMMSMMMMMMWWWWWWWW
        NNNNNNNNNNNNNZJJJJJJJJGGGGZGGGGGGGGGGGOOOORRRRRRRRWWWWWWWRWMWQQQQQQQQQPNNNOOOOOOOOOBTTTCCCBBBBNINNNNNYNYYYYYYFFFFFFFAKEKKMMMMMMMMMMWWWWWTTWW
        NNNCCNNNNNNNNNNJJJJJJJGGGZZZGGGGGGGGGGGOOLLTTRRRRRWWWWWWWWWWWWQQQQQQQQQQQOOOOOOOOOOBBBTTCCBBBBBNNTNNYYYYYYYYYFFFFFFAAAKKMMMMMMMMMMMWWWWWWTTW
        CCCCCNNNNNNNNJJJJJJJJCZZZZZZZGGGGGGGGGGOOLLTTRRRRRWWWWWWWWWQQQQQQQQQQQQQDDOOOOOOBOBBBBBBBBBBBBBYTTNYYYYYYYYYYFFFAALAAAAAMMMMMMMMMMMMWWWWWWTW
        CCCCCIINNNNNJJJJJJJJJJZZZZZZZGGGGGGGGGGGGTTTRRRRRWWWWWWWWWWQQQQQQQQQQQQQDDOOOOOOBBBBBBBBBBBBBBBYYYYYYYYYYYYYFFFFFAAAAAAAMMMMMMMMMMMMMWWWWWWW
        CCCCCCCCNNNKKKKJJJJJZZZZZZZZGGGGGGGGGGYTTTTTTRRWRWWWWWWKKZQQQQQQQHQZZTQQQOOOOOOOOBBBBBBBBBBBBBBYYYYYYYYYYYYYFFFFAAAAAAAAMMMMMMMMMMMMMWWWWWWW
        CCCCCCCCCNNNKJJJJJJZZZZZZZZZZGGGGGGJGTTTTTTTTRWWWWWWWWKKKKQQQQQQQQQQZZQZZOZOOOOOOBBBBBBBBBBBBKKYYYYYYYYYYYYWWFFFAAAAAAMMMMMMMMVVVMMMMWWWWWWW
        CCCCCCCCCNNNKMJJJJJZZZZZZWWWNWWKGGOJOTTTTTTTBRWWWWWWWWKKKKQQQQQQQQVZZZZZZZZOOOBBOBBBBBBBBKKBKKKKYYYYYYYYYYWWWFWFAAAAAAAMMMVVVVVVVVMMWWWWWWWW
        CCCCCCCCCCNNJJJJJJJZZZZZZZWWWWWWWGOOOOTTTTTTTWWWWWWWWKKKKKQQQQTQQQVVVVZZZZZMGBBBBBBBBBBBBBKKKKKYYYYYYYYYYWWWWWWWAAAAAAAMMMMVVVVVVVWWWWPPPPPW
        CCCCCCCCCNNNNJJJJJJZZZZZZZZWWZZZWOOOOTTTTTTTWWWWWWWWWKKKKEEEZZZZZZZVVVZZZZZGGBBBBBBBBBBKKKKKKKLLLYYYYYYYYGWWWWWWWWWWAAMMMMMMVVVVWWWWWWPDPPPW
        CCCCCCCCCCNFNFJJJZJJZZZZZZZWWZZBBBBOQQQTTTTTTWWWWWWWWKKKKKEGGZZZZZZZZZZZZZZGGGGGBBBBBKKKKKKKKKKLLYYYYYYYYGWWWWWWWWWWWWPMMMVVVVVVWWWPPPPPPPPP
        CCCCCCCCCCNFNFFZZZZZZZZZZZWWWZZBBBBBBBBBBTTRWWWWWWWWWWKKEEEGGGRZHHZZZZZZZZGGGGGBBBBBKKKKKKKKKKKKKYYYYYYYYWWWWWWWWWWWWWPPPPVVVVVVWWWPPPPPPPPP
        CCCCCCCCCCCFFFFFFZZZZZZZZZZZZZZBBBBBBBBBBTRRRRRRWWWWWWWWEEGGGGRRRHZZZZZZZZGGGGGGBBBEEEGKKKKKKKKKKYYYYYYYWWWWWWWWWWWWWWWPPPPDDVDWWWPPPPPPPPPP
        CCCCCCCCCCCFFFFFFFZZZZZZZZZZZZWBBBBBBBBBBQRRRRRRWRRRWWWWWEEGGGGRHHHZZZZZGGGGGGGGBBEEEEEKKKKKKKKKKKYKMJYYLWWWWWWWWWWWWWWWWWDDDDDWWWPPPPPPPPPP
        CCCCCCCCCCCCXPFFFFFZZZZZZZZZZZWBBBBBBBBBBQRRRRRRRRRRWRWWWEWRRRRRHHZZZZZZGGGGGGGGGBEEEEEEEEEKKKKKKKYKMMMLLLLWWWWWWTWWDDDDDDDDDDWWWWPPPPPPPPPP
        CCCCCCCCCCCCPPPPFFFZZZZZZZZZZZBBBBBBBBBORRRRRRRRRRRRRRWWWWWWRRRHHHHHHHZZGGGGGGGGGGEEEEEEEEKKKKKKKKKKMMMMMLLLLWWWTTWTTTDDDDDDDDDDDWPPPPRRPPPC
        CCCCCCCCCCCPPPPPFFFFZZZZZZZZZZBBBBBBBBBOLLRRRRRRRRRRRRWWWWWRRRHHHHHHHHHGGGGGGGGGGGEEEEEEEEEKKKKKKMMMMMMMMMMLLLWWTTTTTTTTDDDDDDDDDDPPPPPRPPPP
        CCCCCCCCCCCCPPPAFPLFZZZZZZZZZZBBBBBLLLLLLLRRRRRRRRRRRRWRWRRRRRHHHHHHHHHHGGGGGGGBBBGEEEEEEEEEKKKKMMMMMMMMMMMLNNNNTTTTTTTDDDDDDDDDCCCPPPPRRRPR
        CCCCCCCCCCPPPPPPPPBBZZZZZZZZBBBBBBBLLLLLLLLYYRRRRRRRRRRRRRRRRHHHHHHHHHHHGGGGGGGBBBGGGEEEEKKKKKKKMMMMMMMMMMMLLNNNNTTTTDDDDDDDDDDCCCCPPRRRRRPR
        CCCCCCCCCCCPPPPPPPBBBBBBBBDWBBBBBBBLLLLLLLLLRRRRRRRRRRRURRRRHHHHHHHHHHHBBBBBBBBBBBGGGEEEEEKKKKKMMMMMMMMMMMMLLNNNTTTTTTTDDDDDDDCCCRRRRRRRRRRR
        CCCCCCCCCCPPPPPPPBBBBBBBDDDWBBBBBBBLLLLLLLLLRBRRARLLLLRUURRRHWHHHHHHHHGBBBBBBBBBBGGQGEEEEEEKKKKMMMMMMMMMMMMMLNNNTTTTTTTTTDDDDDDWRRRRRRRRRRRR
        CCCCCCCCCCPPPPPPPBBBBBBDDDDDBBBBBBBBBBOLLLLLBBRRRLLLLLRUUUURRHHHHHHHHHHBBBBBBBBBBGGGGEEEEKKKKKMMMMMMMMMMMNNNNNNNNNNNTTTTWDDDDDWWRRRRRRRRRRRR
        CCBBBBCCCCPPPPPPPBBBBBBBBDDDBBBBBBBBBBLLLLLLBBRRLLLLLLRUUUUURHHHHHHHHHHBBBBBBBBBBAAAAEEEEKKKKKKKMMMMMMMMMNNNNNNNNNNNTWWWWWWWDWWWWRRRRRRRRRRR
        RRBRRBCBBCPPPPPPPBBBBBMMDDDDBBBBBBBBBBBLLLLLBBBRBLLLJJJUUUUUUEHHHHHHQQHBBBBBBBBBBAAAAEEEKKKKHHHHHHHHMMMMMNNNNNNNNNNNTWXWWWWWWWWWWWHRRRRRRRRR
        RRRRRBBBBBBBJPPBBBBBBBBBBDDDBBBBBBBBBBBLLLLLLBBBBBBLJJJBUUUUUEEHHHHQRQQQBBBBQQAAPAAAAEEAKKKKHHHHHHHHMZMMMNNNNNNNNNNNNWXWWWWWWWWWWWHRRRRRRRRR
        RRRBBBBBBBBJJPPBBBBBBBBBBBDDIIIIIIIIBBBLLLYLTTBBBBBLJJBBBUUUUEEHHHHQQQQQBBBBQQAAAAAAYEAAAKKKHHHHHHHHMZNNNNNNNNNNNNNXXXXWWZZZWWWJWWRRRRRRRRRR
        RRRBBRBBBIJJIBBBBBBBBBBBBBIIIIIIIIIIBBBLLLLLTTBBBBBLBJBBBBUBBHHHHHHHQQQQBBBBAAAAAAAAAAAPYKKKHHHHHHHHMZZZNNNNNNNNNNNNNXXXXZZBZZJJWWRRRRRRRRRR
        SSSSSSXBBIJIIIIBBBBBBBBBPIIIIIIIIILLLLLLLLLTTTBBBBBLBBBBBBBBBHHHHHHHQQQQBBBBAAAAAAAAAEEEEKKKYZZHHHHZZZZZZNNNNNNNNNNNXXXXZZZZZZJJJJJARRRRRRRR
        SLSSSSSIIIIIIIIBBBBBBBBIIIIIIIIIIIIILLLLLLLLTBBBBBBBBPBBBBBBHHHHHHQQQQQQQQQQAAAAAAAAAEEEEYKKYYYHHHHZZZZZZNNNNNNNNNXXXXXXZZZZZZZJJJJAAARRRRRR
        SSSSRSSIIIIIIIBBBBBBBBBBIIIIIIIIIIIELLLLLLTTTTBBBBPPPPPBIIBBBHHHHHHQQQQQQQQQQAAAAAAAAEEEEYYKYRRHHHHZZZZZZNNNNNNNNNNXXXZZZZZZZZJJJAAAAAARRRRR
        SSSSSSSPIIIIIIIIBBBBBBBKIIIIIIIIIIILLLLLLLTTTBBIIPPPPPIIIBBBBBHHHHHQQQQQQQQQQAAAAAAAAEEEEYYYYRRHHHHZZZZZZZNNNOONTTNNZXZZZZZZZJJJAAAAAAARRRRR
        SSSSSSPPPIIIIIIIIBBEBBBIIIIIIIIIIIILLLLLLLWTIOOIIIIIPIIIIBBBBHHHHHHQQQQQQQQQQQQAAAAAAEEEEYYYYRRRVVVZZZZZZZZNNNNNTTTZZXZZZZZZZZZZAAAAAAARRRRR
        SSSSSSIIIIIIIIIIIIEEBBQQIIIIIIIIIIIILLLLLLLLOOOIIIIIPIIIIBHBHHHHHHHHHQQQQQQQFQQAAAAAAEEEEYYYYYRRRVVVZVZZZZQCQQTTTTTTZZZZZZZZZAAAAAAAAAAAKRRR
        SSSSSSIIIIIIIIIIIIIIIIQQIIIIIIIIIILLLLLLLLLLROOOIIIIIIIIIHHHHHHHHHHHHQQQQQQQFFFBAAAAAEEEEYYRRRRRRVVVVVVVVQQQQQQTTTTTZZZZZZZZZOAAAAAAAAAAKRRF
        SSSSIIIIIIIIIIIIIIIIIIIQQIIIIIIIIILLLLLLLLLLOOOOOIIIIIFIIHHHHHHHDDDDQQQQQQQQQQFFQAEEEEEEEEEYRRRRRVVVVVVCVQQQQQLQTTTZZZZNZZZXAOAAAAAAAAAAAAAF
        SSIIIIIIIIIIIIIIIYYIJIIQQIIIIIIIIILLLLLLLLLLIIIIIIIIIIIJIHHHHHHHDDDDDQKQQQQQQQQFQAEEEEEEEEEYRRVVVVVVVVVCCQQQQQQQTTTTZZZNNNTTAAAAAAAAAAAAAAAF
        SSISSSIIIIIIIIHIIYIIHQQQQQIAAIIIIILLLLLLLLLLLIIIIIIIIIJJJJHHHHHHDDDDQQKQAQQQQQQQQAEEEEEEEEEYVVVVVVVVVVVVVVQQQQQQTTTTBBNNNTTTTAAAAAAAAAAAAAAF
        SSSSSSIIIIIIIHHHHHHHHHQQQAAAAIIAIALLLLLLHLLLIIIIIIIJJJJJHHHHHHHPDDDDDDDQQQSQQQQQQQEEEEEEEEEYYVVVVVVVVVVVFQQQQQQQQQTBBITNTTTTTTTTAAAAAAAAAAAF
        SSSSSSIIIHHIHHHHHHHHHHQQQQAAAAAAAAALHHHHHHHIIIIIEEJJJJJJJHHPPPPPDDDDDDDDSSSQQQQQQQEEEEEEEEEYVVVVVVVVVVVVQQQQQQQQQQQBBTTTTTTTTTTTTAAAAAAAABBB
        SSSSSSIIIHHHHHHHHHHHHHQAAAAAAAAAAAAHHHHHHHIIEEIEEJJJJJJJJEEPPPDDDDDDDDBYYSSQQQQQQQAYYDYYYYYYVVVRVVVVVVVVQQQQQQQQQQKBBOTTTTTTTTTTAAAAAAABBBBB
        RSSSSSSIIHHHHHHHHHHHHHQAAAAAAAHAAAAHHHHHHHHHHEEEEJJJJJJJEEEPDDDDDDDDDYBBYYQQQQQQQYYYYYYYYYYYYYVVVVVVVVVQQQQQQQQQQBBBBBZTTTTTTTTTTTAAAAABOBBB
        RSSSSSSHHHHHHHHHHHHHHHQQQDAAAAHHHHHHHHHHEHEEEEEEEEJEJEEEEEEDDDDDDDDDDYYYYYSQQQQQQQYYYYYYYYYYYYVVVVVVVVVVQQQQQQQBHBBBBBBTTTTTTTTTTTHAAAAABBBB
        RRRRRRVHHHHHHHHHHHHHHHHDDDAAAHHHHHHHHHHHEEEEEEEEEEJEEEEEDDDDDDDDDDDDDYYYIYSQQQQQQQQYYYYYYYYYYYVVVVVVVVVVVQQQQAAAAAAAAABBTTTTTTTTHHHAHAHBBBBB
        RRRRRRVHVVHVHHHHHHHHFFHDDDAAADHHHHHHHHHHECEEEEEEEEEEEEEDDDDDDDDDDDDDDYLYYYSSSSSSQQQYYYYYYYYYYVVVVVVVVVVVVVQQQAAAAAAAAABWTVVTTTTTHHHHHHHHHBBB
        RRRRRRVHVVVVVHHHHHHHFFFFDDDDDDHHHHHHHHHHECEEEEEEEEEEEEEDDDDDDDDDDDDDDLLLYQEESSSSSSSYYYYYYYYYYHVVVVVVVVVQQAAAAAAAAAAAAABSSSSTTTAHHHHHHHHHHBBB
        RRRRVVVVVVVVVVHHHHHHHFFDDDDDDDDHHDHHHHHHHEEEEEEEEETTEETDDDDDDDDDDDDDLLLLLEEEESSSSSSSSYYYYYYYYHLVVVLVVPIQQAAAAAAAAAAAAASSSSQTSTNNHHHHHHHHHHHH
        RRRRRVVVVVVVVVHHHHHHHFFDFDDDDDDDDDDHDHHHHHEEEEEEEETTTTTTTDDDDDDDDDDDLLZZZZEEEEEEESSSSYYYYYYXXLLLLLLIIIIIIAAAAAAAAAAAAASSSSSSSSNNNHHHHHHHHHHH
        RRRRVVVVVVVVVVDHHHHHFFFFFIDDDDDDDDDDDNHHHHEEEEEEEETTTTTTTTDDDDDDDDDDDZZZZZZEEEEEESEESEGYNXXXXXLLLLLIIIIIIAAAAAAAAAAAAASSSSSSNNNNNHHHHHHHHHHH
        RRRRVVVVVVVVVVVHHHHFFFFFIIDDDDDDDDDDDNNHHNQQEEEEEETTTTTTTZDDDDDDDDDDZZZZZZEEEEEEEEEEEEGXXXXXLLLLLLLLIIIIIAAAAAAAAQSSSSSSSSSSSSVHHHHHHHHHHHHH
        RRRRVVVVVVVVVVVJOHJFJJJIIDDDDDDDDDDDDNNHNNNNIEEEEETTTTTTTDDDDDDDDDDDZZZZZZZZZEEEEEEEEEEEXXXXXXXLLLLLLIIAAAAAAAAAAQSSSSSSSSSSGSVHHHHHHHHHHHHH
        RRRVVVVVVVVVVVVJOJJJJJJJIDDDDDDDDDDDNNNNNNNIIEYYEKTTTTTTTTDDDDNDNDZZZZZZZZZZEEEEEEEEEEXXXXXXXLLLLLIIIIIAAAAAAAAAAAAAZSSSSSSSSSSSVVVHHHHHHHHH
        RKRRVVVVVVVVVVJJJJJJJJJIIIIIDDDDDDDDDNNNNNNIIINYYATNTBTTTTDDDDNNNNNZZZZZZZZZEEEEEEEEEXXXXXXQLLLLLLIIIIIAAAAAAAAAAAAASSSSSSSSSCVVVVVHHHHHHHHH
        KKRRRVNVVVVVJJJJJJJJJJIIIIIIDDDDDDDDDNNNNNNNNNNYNAANABTTTTADDDNNNNNNZZZZZZZZEEEEEEEEXXXXXXQQQLLQLQIIIIIAAAAAAAAAAAAAASSSSSSSSVVVVVHHHHHHHHHH
        KKKKRNNVVVVVJJJJJJJJJIIIIIIDDDDRDDDDNNNNNNNNNNNNNAAAAATTAAAADDNNNNNNZZZZZZZEEEEEEEEXXXXXXXQQQOJJJJJJQIIAAAAAAAAAAAAAASSSSSSSSVVVVVVVVVVHHHHH
        WKKKWNVVVVVFJJJJJJJJJIIIIIIDDDDRRDNNNNNNNNNNNNUUUAAAAAAAAAAAADNNNNNSSZZZZEEEEEEEEEEEXXXJJJJJJJJJJJJJQIIIMEEEEEEEAAAAAEESSSYVVVVVVVVVVWVHHHHH
        WWWWWNNVVVVVVJJJJJJJJIIIIIIDDDRRRRRRNNNNNNNNNNNAAAAAAAAAAAAAADNNNNNSSSZZZEEEEEEEEEEFXSSJJJJJJJJJJJJJQQDSMMMEEEEEAAAAAESSSYYYVVVVVVVVVVVHHHHH
        WBWWWNNNVVVVJJJJJJJJJIIIIDDDDRRRRRRRNNNNNNNNNNEAAAAAAAAAAAAAANNNNNNZZZZZEEEEEEEEEEEEXSSJJJJJJJJJJJJJQQSSSSSSEEEEAAAAAEESSVVVVVVVVVVVVVVHHHHA
        BBWWWNNNVVJJJJJJJJJJJIIDDDDDRRRRRRRNNNNNNNNNNNEEEAAAAAAAAAAAANNNNNNSSSSEEEEEEEQEEENNNSSSJJJJJJJJJJJJQQSSSSSEEEEEAAAAEEEEVVVVVVVVVVVVVVHHHHHA
        BBWWWWNNNNNJJJJJJJJJIIIDDLLORRRRRRRRNNNNNNNNNNEEEAAAAAAAAAAAANNNNNNNNNEEEHHHEEEEEEEEESSSJJJJJJJJJJJJQSSSSPPPEPEEAAAAEEEEVVVVVVVVVVVVVVAAAAHA
        CBBBGGNGGNNNJJJJJJJJJILLLLLLQLRRRRROOOONNYNEEEEEAAAEEAAAAAAEENNNVVNNNNHHHHHEEEEEEEEESSSJJJJJJJJJJJJJSSSSSPPPPPPPAAAAEEEEEVVVVVVVVVSSVVVAAAAA
        CBBBGGGGGNNNNJJXJJJJJXBBBBLLLLRRRRRROOOONNNEOEEEEAAEEAAAAAAEEENNNVNNNNNNNHHEEEEESSSSSSSJJJJJJJJJSSSSSSSSSPPPPPPPPPEEEEEOOVVVVVVVSSSAAAAAAAAA
        CCBBGGGGGNNNNJXXJXXXXXBBBKLLLFRURRUUOOOOONOOOOOEEEEEEAEAAAEEENNNNNNNNNNNNEHEEEHEESSSSSSJJJJJSSSSSSSSSSSSPPPPPPPPPEEEEEEEOAAVVVVVVVAAAAAAAAAA
        CCBGGGGGGGNNXXXXXXXXXBBKBKKLLKUUUUOOOOOOOOOOOOOEEEEEEAEAEEEENNNNNNNNNNNNREEEEHHEESSSSSSJJJJJSSSSSSSSSSSSPPPPPPPPPEEEEEEEERAAAAAVAAAAAAAAAAAA
        CCCCGGGGGGNNXXXXXXXXXKKKKKKKLKKUUUUOOOOOOOOOOEEEEEEEEEEAEEEEEENNNNNNNNNNNNNJJIHHEHSWSSSJJJJJSSSSSSSSSPPMPPPPPPPPPEEEEEEEERAAAAAAAAAAAAAAAAAA
        CCCCGGGGGGGGXXXXXXXXXKKKKKKKKKKUUUUUDDOOOOOOOEEEEEEEEEEEEEEENNNNNNNNNNNNNJJJJIHHHHSWWSSJJJJJSKKKKSSSSSPPPPPPPPPPPVVEEEEEEEAAADAAAAAAAAAAAAAA
        CCCCGGGGGGGGXXXXXXXXXKKKKKKKKKKKKUUUDDOOOOOOOOEEEEEEEEEEEREEENNNNNNNNNNNNJJJIIIIISSSSVSSSRRSSKKKKSKSSPPZPPPPPPPPPPVEEEEEFFFADDADAAAAAAAAAAAA
        CCCGGGGGGGGGXXXXXXXXXXXKKKKKKKKKKKDDDNNOOOOOOEEEEEEEEEEEEREEENNNNNNNNNNXWJJJIIIIVVVVVVVVSKKKKKKKKSKKKKKZZPPPPPPPPPEEOEEEEFFDDDDDDDAAAAAAAAAA
        CCCCGGGGGGGGFXXXXXXXXKKKKKKKKKKKDDDDDNNNOOOOEEEEEELEEEEEERRRRRNNNNNNNNNXWJJJIIIIIIVVVVVIIKKKKKKKKKKKKKKKPPPPEEEPPPEEELEEEEDDDDDDDDAAAAAAAJAA
        CCCGGGGGGGGGFFXXLLXXKKKKKKKKKKKDDDDDDNNOOOOOEEEELLLLLLEEEERERRRNNNYNNNNWWWWIIIIIIIVIIIVIIYKKKKKKKKKKLLLKKPPPPEEEEPEEZEEEECDDDDDDDDAAAAAAXAAA
        CCCCGGGGGGGLLFFLLLLXXKKKKKKKKKKDDDDDNNOOOOOEELLLLLLLLLEEEEEEENNNNNMMMNNWWWIIIIIIIIIIIIIIBKKKKKKKKKKLLLKKEPEEEEEEEEEEEEEAEDDDDDDDDDDAXAXXXAAA
        CCCCGGGGGGLLLLLLLLXXDDKKKKKDKDDDDDDDDNNNNNNNNLLLLLLLLLEEEEEZENNRRRMLLLWWWWWWWIIIIIIIIIIIBKKKKKKKKKKKLLLLEEEEEEEEEEEEEEEAEADDDDDDDDDXXXXXXXXC
        CCCCGGGGGGWLLLLLLLXDDKKKKKKDKDDDDDDIIINNNNNNLLLLLLLLLLEEEEZZNNNMMMMLMMMWWWWWWIIIIIIIIQIBBBKKKKKKKKKKKKLLEEEEEEEEEEEEEPPAAADDDDDDDXXXXXXXXXXC
        CCCCGFGGGGWLLLLLLLLDDKKKDDDDDDDDDIIIIINNNNNNNLLLLLLLLLLEZZZMMMMMMMMMMMMGWWWWIIIIIIIIIQQQBBKKKKKKKKKKKKKLEEEEEEEEEEEEEEPAAADDDDDDDXXXXXXCCCCC
        CCCCCLLMGLLLLLLLLLLDDDKDDWDDDDDNNNNIIIIIIINNNNNLLLSSLSLZZZZZMMMMMMMMMMMMMWWWIIIIIIIIIIQQBBBKKKKKKKKKKKKKEEEEEEEEEEEEEPPPPADDDDDHDXXXXXMMMCCC
        CCLLLLLLLLLLLLLLLLLDDDKDDWWDWWWWNNNIIIIINNNNNNLLNLSSSSLLZZZMMMMMMMMMMMMMMWWWWIIIIIIIIKQQBBQKKKKKKKKKKKKKEEEEEEEEEEPEEEPPPDDDDDDDDXXXXXXMMMMM
        CCCCLLLLLLLLLLLLLLLDDDDDWWWWWWPPNNNIIIIJNNNNNNNNNLSSSULLZZZZMMMMMMMMMMMMMMWWIIIQIQIQQQQQBBQMKKKKKKKKKKKKEEEEEEEEEEPEEPPPDDDDDTDDDXXXXXXMMMMM
        CCCCLLLLLLLLLLLLLLLDDDDDDWWWWWWITIIIIIIINNNNNNNNNNSNSUZZZZZMMMMMMMMMMMMMMMWWIIQQQQQQQQQQQBQQXKKKKVVHHKKKKEEEEZEEEEPPPPPPPDDDDDDDXXXXXXXMMMMM
        CCCCCLLLLLLLLLLLLLLLLLDDDWWWWWWIIIIIIIIINNNNNNNNNNNNNQQZZZZZMMMMMMMMMMMMMMWWIIZZQQQQQQQQKQQQXXKKVVHHHHHHEEEEEZSEEEPPPPPVPPDVXXXXXXXMXXXMMMMM
        CCCCCLTLLLLLLLLLLLPLDDDDDWWWWWWIIIIIIIIINNNNNNNNNNNNQQZZZZZZMMMMMMMMMMMMMMMMZZZQQQQQQQQQQQQXXXXXHHHHHHHHHHZZZZSEPPPPPPPVVVVVVVXXXXXMMMMMMMMM
        CCCCCCTTLLLLLLLLTLLDDDDDDDWWWWWWWIIIIIINNNNNNNNNNNNNQQQQQQQQQMMMMMMMOOOMMMMZZZQQQQQQQQQBBQQXXHHHHHHHHHHHHHZZZZZZPPPPPPPVVVVVVVVXVVXMMMMMMMMM
        CCCCCCCLLLLLLLLLTLLDDDWWWDWWWWWWWIWTIINNNNNNNNNNNNNNQQQQHQQQKKKKKOMOOXOMMMMZZZZQQQQQQQQQQQQQXHHHHHHHHHHHGZZZZZLZPPPPPPPXNVVVVVVVVVMMMMMMMMMM
        RRCCCCRRLYLLLLTTTIDDDDWWWWWOWWWWWWWWIIWNNNNNNNNNNNNNQQQQQQQQQQKKKOOOOOOMMMMZZZZZQQQQQQQQQQQQHHHHHHHHHHHHGZZZZZZZPPPPXXPXVVVVVVVVVVMMMMMMMMMM
        RCCCRRRLLYRAALLTRIIIIIBWWWWWWWWWWWWWWWWNNNNNNNXNNNNQQQQQQQQQQKKKKKOOOMMMMMMMZZZZQQQQQQQQQQQQWHHHHHHHHHHHHZZZZZZZYPPPXXXXDVVVVVVVVVVMMMMMMMMM
        RRRCRRRRRRRRRZRRRIIIIIBBWWZWWWWWWWWWWWNNNNNNNXXXNNNQQQQQQQQQKKKKKKOOOOMMMMMMZKKKKKQQQQQQQQQQWWHHHHHHHHHHSZZZZZZZMPPPXXXXXVVXMMVVVVMMMMMMMMMM
        RRRRRRRRRRRRRRRRIIIIIIBWWWZZWWWWWWWWWNNNNNNTTXXNNNQQQQQQQQQQQQNNNNNOOOMMMMMMZZZZZZQQQQQQQQQWWWHHHHHHHHHSSZZZZZZMMMMMXXXXXXXXMMVVVVTMMMMMMMMM
        RRRRRRRRRRRRRRFRIIIIIIBBBWWZZWWWWWWWWNNNNNTTTXNNQQQQQQQQQQQQQQZNNNNNNNMMMMMMMZZZZZQWWQQQQQQWWWWHHHHHHHHHSZZZMZMMMXXXXXXXXXXXXXXXVCMMMMMMMMMM
        RRRRRRRRRRRRRRRIIIIIIIIBBWWZZZWWWWWWWWWNCTTTTTQQQQQQQQQQQQQQQSNNNNNNNNNNMMMMMMGGGGQWWWWQQQQWWWWHLHHHHHHSSSZMMMMMMXXXXXXXXXXXXXXCVCMMMMMMMMMM
        RRRRRRRRRRRRRRRIIIIIIIISBBBIZZZWWWWWWWTTTTTTTTQQQQQQQBBQQMQPQNNNNNNNNNNNMMMMMMGIGGGGWWWQQVQLLLWLLHHHHHHHSMMMMMMMMMXXXXXXXXXXXXCCCCMMMMMMMMMM
        RRRRRRRRRRRRRRRIIIIIIGSSBBIIIIZZWWWWWTTTTTTTTTTQQQGQQBBQQQQQHNNNNNNNNNNNMMMGGGGGGGGGWWWWQQTTLLLLLHUHHHHHSMMMMMMMMMJJTXTTXXXXXXCCLLKKMMMMMMMM
        RRRRRRRRRRRRRRCIIIIISSSSBBSIIIIIWWWWWWITTTTTTTTTQQGQQBBBQQQNHNNNNNNNNNNNNMMMMGGGGGGGGGWTTTTTTTLLLLUHHHHSSMMMMMMMMMJJTTTTXXXXXLLLLLKLLMMMMMTM
        RZRRRRRRRRRRRRIIIIIIIISSSSSIIIIIWWWIIIITTTTTTTTTTTGQAGBBQBQNNNNNNNNNNNNNNNMMMGGGGGGGGTTTTTTTTTLLLTTHHHHSMMMIMMMJMJJJJTTTXXXXXZZLLLLLLWMWMMMZ
        ZZRRRRJRRRRRRRIIIIIIIISSSSSIIIIIWIIIIIIIIITTTTGGGGGGGGBBBBBNNNNNNNNNNNNNNNMMMMMGGGGGGTTTTTTTTTLLTTTHLAAAAMMAJJJJJJJJTTTTXXXXXLLLLLLLLWWWMMMM
        ZZZRRRJJRRRRRIIIIIIISSSSSSIIIIIIIIIIIGGIIIIITTGGGGGGGGGGGBBBNNNNNNNNNNNNNMMMMMMMMGGGTTTTTTTTTTTTTTAAAAAAAMAAJJJJJJJJTTTTXXXXXXLLLLLLLLWWMMWW
        ZZZRZZJJJJRJIIIIIIIIISPSSSFPIIIIIIIIIGGIIIIGGGGGGGGGGGGGGBNNNNNNNNNNNNWNMMMMMMMMMMMTTTTTTTTTTTTTTTTAAAAAAQAAAAAJJJJJJJTXXXXXXXLLLLLLLLLWWWWW
        ZZZZZJJJJJJJJJJIIIIIIIIJSFFFIIIIIIIIIGIIIIIGGGGGGGGGGGGGGGQYNNNNNNNYNNYNMMMMMMMMMMMTDTTTTTTTTTTTTTAAAAAAAAAAAAAJJJJXXXXXXXXXXXLLLLLLLFLWWWWW
        CZZZZJJJJJJJJJIIIIIIJIJJFFFFIIIIIIIIIIIIIIGGGGGGGGGGGGGGGYYYYYYNNNNYYYYYYYDMMMMMMMMMDDTTTTTTTTTTTTAAAAAAAAAAAAJJJJJXXXXXXXXXAAAALLLLLLLLWWWW
        CZZZZJJZZJJJJJJJJIIIJIJFFFFFIIIIIIIIIIIIIIIGGGGGGGGGGGGGGYYYYYYYYYYYYYYYYYDMMMMMMMMDDDDTTTTTTTTTTTADAAAAAAAAYJJJJJJJJXXXXXXXXXXALLLLLLXBBWWW
        ZZZZZZZZAZJJJRJRRRIIJJJOWWYYIIIIIIIIOOIIIIGGGGGGGGGGGGAAAYYYYYYYYYYYYYYYYYYMMXMMMMDDDDDDDDTTDDTTTTDAAAAAAAAAYJJJJJJJWWWXWWWXXAAAAALLYLXBBWBB
        ZZZZZZZZAZJRRRRRRJJIJJOOWWYYIIYIOOOOOOOIIGGGGGGGGGGGAGAAYYYYYYYYYYYYYYYYYYYYMMMMEDDDDDDDDDDDDDDDTDDDAAAAAAAAADJJJJJJWWWWWWWWAAAAALLLLLLBBBBB
        ZZZZZZZZZZJJRRRJJJJJJOOOWYYYYYYIOOOOOOOOGGGGGGGGGGGGAGAAAYYYYYYYYYYSYYYYYYYEEEMEEEEDDDDDDDDDDDDDDDDDDAAAAAADDDDJDJKWWWWWWWAAAAAALLLSBBBBBBBB
        ZZZZZZZZZJJWWWWJJJJOJOOOOOOCYYBOOOOOOOOOGGSGGGGGGGGGAAAAYYYYYYYYYYSSSSYYEEEEEEEEEEDDDDDDDDDDDDDDDDDDDAADDDDDDDDDDKKKWKKWWWWWAAAAALLSBBBBBBBB
        ZZZZZZZZZZZWWWWJJJJOOOOOOOOOOFOOOOOOOOOOOGGGGGGDDDQQQQQAAYYYYYYYYSSSSSSYEEEEEEEEEDDDDDDDDDDDDDDDDDDDDDDDDDDDDDKKKKKKKKKWWWXXAAAAASSSSBBBBBBB
        ZZZZZZZZZWWWWWWWWJOOOOOOOOOOIOOOOOOOOOOOGBBBGGGDDQQQQQQQYYYYYYYYYYGSSSSSSSEEEEEEEDDDDDDDDDDDDDDDDDDDDDDDDDDDDKKKKKKKKKKWWXXXAAAAAASSSBBBBBBB
        ZZZZZZWWWWWWWWWWJJOOOOOOOOOOOOAOOOOOOOOBBBBBGTSSDQQQQQQQYYYYYYYYOOCCSSSSSEEEEEEEEEDDDDDDDDDDDDDDEDDDDDDDSDDDDKEKKKKKKKKXXXXXWWWAAABBBBBBBBBB
        ZZZZZZWWWWWWWWWWJJOOOOOOOOOOOOOOOOOOOBBBBBBBBSSSSQQQQQQQYVYYYYYYYOOCCCSSCEEEEEEEEEEDDDDDDDDDDDDDEEEDSSDDSDDDKKKKKKKKKKKXXXXXWWWWBUBBBBBBBBBB
        SZZZZZZWWWWWWWWSOOOOOOOOOOOOOOOOOOOOBBBBBBBBBSSSQQQQQQQQYYYYYYYMYOOCCCSSCCCCCCCEEEEDDDDDDDDDDDDEEEEEPSSSSDKKKKIKKKKKKKKBXXXXXWWWBBBBBBBBBBBB
        ZZWWWWZWWWWWWWWWOOOOOOOOOOOOOOOOOOOOOOOBBBBBBBBBQQQQQQQQQYYYYOOYYOKKCCCCCCCCCCCCEEEDDDDDDDDZEEEEEEESSSSSSSSSDKKKKKKKKKKXXXXXXWWWWWWBBBBBBBBB
        ZWWWWWWWWWWWWWWWWNNNOOOOOOOOOOOOOOOOOOBBBBBBBBBBQQQQQQQQQQQQYOOOOOKKKCCCCCCCCCCEEEEDDDEDDDDDEEEEEEFSSSSSSSSSSKKKKKKKKKXXXXXXWWWWWWWBBBBBBBBB
        MWWWWWWWWWWWWWWNNNNNOOOOOOOOOOOOOOOOOOBOBBBBBBBBBSQQQQQQQQQQQOOOOOCCKKCCCCCCCCCEEEEEEEEEEDDEEEEEEEEESSSSSSSSKKKKKKKKKKXXXXXWWWWWWBBBBBBBBBBB
        MMWWWWWWWWWWWWWWWNNNOOOOOOOOOOOOOOOOOOOOBBBBBBBBBBQQQQQQQQQQQOOOOOCCCCCCCCCCLLCEEEEEEEEEEEEEEEEEEEEEMSSSSSISRKIIKKKKGKXXXXXXXWWWWBBBBBBBBBBB
        """;

    [TestCase(TestInput1, "140")]
    [TestCase(TestInput2, "1930")]
    public void Part1(string input, string expectedOutput)
    {
        var testOutput = Solution1(input);
        Console.WriteLine($"{nameof(Part1)} test result: {testOutput}");
        Assert.That(testOutput, Is.EqualTo(expectedOutput));

        // only executed if the test input worked
        var actualOutput = Solution1(Input);
        Console.WriteLine($"{nameof(Part1)} actual result: {actualOutput}");
    }

    [TestCase(TestInput1, "80")]
    [TestCase(TestInput2, "1206")]
    [TestCase(TestInput3, "436")]
    [TestCase(TestInput4, "236")]
    [TestCase(TestInput5, "368")]
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
        var grid = input.Split("\n")
            .Select(l => l.Trim())
            .Select(l => l.ToCharArray())
            .ToArray();
        
        long total = 0;
        var seen = new HashSet<(int x, int y)>();
        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid[0].Length; j++)
            {
                if (seen.Contains((i, j))) continue;
                var (area, perimeter, _) = TraverseFrom(grid, i, j, seen);
                total += area * perimeter;
            }
        }
        
        return total.ToString();
    }

    private static (int area, int perimeter, int sides) TraverseFrom(char[][] grid, int startingPointX, int startingPointY, HashSet<(int x, int y)> seen)
    {
        var value = grid[startingPointX][startingPointY];
        var neighbours = new[] { (0, 1), (1, 0), (0, -1), (-1, 0) };
        var toVisit = new Queue<(int x, int y)>();
        toVisit.Enqueue((startingPointX, startingPointY));
        var area = 0;
        var perimeter = 0;
        var sides = 0;
        while (toVisit.Count > 0)
        {
            var next = toVisit.Dequeue();
            if (!seen.Add((next.x, next.y)))
            {
                continue;
            }

            area++;
            var neighboursFound = 0;
            foreach (var neighbour in neighbours)
            {
                var nX = next.x + neighbour.Item1;
                var nY = next.y + neighbour.Item2;

                if (nX < 0 || nY < 0 || nX >= grid.Length || nY >= grid[0].Length)
                {
                    perimeter++;
                    continue;
                }
                
                var n = grid[nX][nY];
                if (n != value)
                {
                    perimeter++;
                    continue;
                }
                
                if (n == value)
                {
                    neighboursFound++;
                    toVisit.Enqueue((nX, nY));
                }
            }
            
            var newSides = neighboursFound switch
            {
                0 => 4,
                1 => 2,
                2 => CalculateSides(grid, next),
                3 => CalculateSides(grid, next),
                4 => CalculateSides(grid, next),
                _ => throw new ArgumentOutOfRangeException()
            };
            
            sides += newSides;
        }

        return (area, perimeter, sides);
    }

    private static int CalculateSides(char[][] grid, (int x, int y) current)
    {
        char[][] innerCornerMask =
        [
            ['X', 'C', 'A'],
            ['C', 'O', 'A'],
            ['A', 'A', 'A']
        ];
        
        char[][] outerCornerMask =
        [
            ['A', 'C', 'A'],
            ['C', 'O', 'X'],
            ['A', 'X', 'A']
        ];
        
        var innerCornerMasks = Enumerable.Range(0, 3)
            .Aggregate(new List<char[][]>() { innerCornerMask }, (list, _) =>
            {
                list.Add(Rotate90(list.Last()));
                return list;
            }).ToList();

        var outerCornerMasks = Enumerable.Range(0, 3)
            .Aggregate(new List<char[][]>() { outerCornerMask }, (list, _) =>
            {
                list.Add(Rotate90(list.Last()));
                return list;
            }).ToList();
        
        var totalSides = 0;
        foreach (var mask in innerCornerMasks.Union(outerCornerMasks))
        {
            if (IsMatch(grid, current, mask)) totalSides++;
        }

        return totalSides;
    }

    private static bool IsMatch(char[][] grid, (int x, int y) current, char[][] mask)
    {
        var coords = new[]
        {
            (-1, -1), (-1, 0), (-1, 1),
            (0, -1), (0, 0), (0, 1),
            (1, -1), (1, 0), (1, 1)
        };
        
        var originalValue = grid[current.x][current.y];
        
        var coordsIndex = 0;
        for (int i = 0; i < mask.Length; i++)
        {
            for (int j = 0; j < mask[0].Length; j++)
            {
                var adjacentX = current.x + coords[coordsIndex].Item1;
                var adjacentY = current.y + coords[coordsIndex].Item2;
                
                if (adjacentX < 0 || adjacentX >= grid.Length || adjacentY < 0 || adjacentY >= grid[0].Length)
                {
                    if (mask[i][j] is 'A' or 'X')
                    {
                        coordsIndex++;
                        continue;
                    }

                    return false;
                }

                var maskValue = grid[adjacentX][adjacentY];
                if (mask[i][j] is 'C' && maskValue != originalValue)
                    return false;
                
                if (mask[i][j] is 'X' && maskValue == originalValue)
                    return false;

                coordsIndex++;
            }
        }

        return true;
    }

    private static char[][] Rotate90(char[][] last)
    {
        Debug.Assert(last.Length == last[0].Length);
        
        var newGrid = new char[last.Length][];
        for (int i = 0; i < last.Length; i++)
        {
            newGrid[i] = new char[last[i].Length];
            for (int j = 0; j < last[0].Length; j++)
            {
                newGrid[i][j] = last[j][i];
            }
        }

        for (int i = 0; i < newGrid.Length; i++)
        {
            newGrid[i] = newGrid[i].Reverse().ToArray();
        }

        return newGrid;
    }

    private static string Solution2(string input)
    {
        var grid = input.Split("\n")
            .Select(l => l.Trim())
            .Select(l => l.ToCharArray())
            .ToArray();
        
        long total = 0;
        var seen = new HashSet<(int x, int y)>();
        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid[0].Length; j++)
            {
                if (seen.Contains((i, j))) continue;
                var (area, _, sides) = TraverseFrom(grid, i, j, seen);
                total += area * sides;
            }
        }
        
        return total.ToString();
    }
}