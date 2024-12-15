namespace AdventOfCode._2024;

[TestFixture]
public class Day15
{
    private const string TestInput1 =
        """
        ########
        #..O.O.#
        ##@.O..#
        #...O..#
        #.#.O..#
        #...O..#
        #......#
        ########
        
        <^^>>>vv<v>>v<<
        """;

    private const string TestInput2 =
        """
        ##########
        #..O..O.O#
        #......O.#
        #.OO..O.O#
        #..O@..O.#
        #O#..O...#
        #O..O..O.#
        #.OO.O.OO#
        #....O...#
        ##########
        
        <vv>^<v^>v>^vv^v>v<>v^v<v<^vv<<<^><<><>>v<vvv<>^v^>^<<<><<v<<<v^vv^v>^
        vvv<<^>^v^^><<>>><>^<<><^vv^^<>vvv<>><^^v>^>vv<>v<<<<v<^v>^<^^>>>^<v<v
        ><>vv>v^v^<>><>>>><^^>vv>v<^^^>>v^v^<^^>v^^>v^<^v>v<>>v^v^<v>v^^<^^vv<
        <<v<^>>^^^^>>>v^<>vvv^><v<<<>^^^vv^<vvv>^>v<^^^^v<>^>vvvv><>>v^<<^^^^^
        ^><^><>>><>^^<<^^v>>><^<v>^<vv>>v>>>^v><>^v><<<<v>>v<v<v>vvv>^<><<>^><
        ^>><>^v<><^vvv<^^<><v<<<<<><^v<<<><<<^^<v<^^^><^>>^<v^><<<^>>^v<v^v<v^
        >^>>^v>vv>^<<^v<>><<><<v<<v><>v<^vv<<<>^^v^>^^>>><<^v>>v^v><^^>>^<>vv^
        <><^^>^^^<><vvvvv^v<v<<>^v<v>v<<^><<><<><<<^^<<<^<<>><<><^^^>^^<>^>v<>
        ^^>vv<^v^v<vv>^<><v<^v>^^^>>>^^vvv^>vvv<>>>^<^>>>>>^<<^v>^vvv<>^<><<v>
        v^^>>><<^^<>>^v^<v^vv<>v^<<>^<^v^v><^<<<><<^<v><v<>vv>>v><v^<vv<>v^<<^
        """;

    private const string TestInput3 =
        """
        #######
        #...#.#
        #.....#
        #..OO@#
        #..O..#
        #.....#
        #######

        <vv<<^^<<^^
        """;
    
    private const string Input =
        """
        ##################################################
        #....O.##O...#.........#..#O........O....#..O.O..#
        #.O#..#O......O..O#..O#O.....OOO....#..O......O..#
        #.OO.O.O....#..O...#...#..O.OO#....OOO#...O....O.#
        #.OO.OO..OO.O.#O...O..#.#.#....OOO#..O...........#
        #..#....#.......OOO.O.......OOO.O....OO.O.....O.O#
        #........#....O.O.#.#.....O.O...O....O.....O.#..##
        #......O..OO#OOO.....O.#.O.##....OO#O.O.O.....O#.#
        #.OOOO....#....O.....O..O..OO..O#........OO......#
        #....O..........#.OOO.O....OO.O.OO...O.....#.....#
        #.#.O.O.O..O.O..#......O..O...O......O.O..O......#
        #..O.O.#...OO.OOO##.....#OO..O.O...OO.O.##..OOO..#
        #OO....O..O....O...OO......#....O##..........OO..#
        #..OO.#.O....O#...O..O.OO.#O.O...O..O#OO.#O...OO.#
        #..#.O.....#.O.O..O#O...O.OOO.OO....O..#.O.......#
        #....##OO...OOO....#.O.O.............#.......O#O.#
        ##.O.O.....#.......#..OO.OO.O..O.#O..O..O.......##
        #.....O.O..#....#.OO......O...O..........OOO.O##O#
        #.##OO#.O..O....O..O...OO..O....O#.....O..O.#....#
        #..OO....O.#OO...O#...O.O..OO.#.OO.#O....O#..#...#
        ##.#O#OOO....#.O#.#..#O.O...O#.OOO.O#....O.O.....#
        #.O....O..OOO.OOO.O.O..OO.O.#....O.O....O..O#O...#
        #.O..O..O#O..O.O..O.O....O..#..OOO.....#..O...O..#
        #..O....O#....O.....O...O....#....O..OO..........#
        #.....OO....OO.O.#..O..#@#..O.O#.O.OO.OO..O.O....#
        #OO..O......OO.O.#.#...OO#....O#.....#...##..O..O#
        #O#O.#O.....O..OO#...OO.O........#.O.O........#.O#
        #........#.O....#O.#.O...#...##O..O.O..#....OO#..#
        #...OO.#O..O.O........OO.O.O.......OOO..#..O..O.O#
        #OO..OOO.#...OO.O...OOO.OO...........O..O...O..OO#
        #.O#O.....O....#.#...O.O..O.O...OO.....OOO..#O..O#
        #.#O.#.....O.OOOOO.#OO..O.O....##.....OO.OO......#
        #.O..OO.....#O.......#...O.O.O.O#....#O..O...O...#
        #...OO.O.#OOOOO...O...#.....#....#......#OOOO..#.#
        #....O...#.OO.........O..#O.O.O..O.....OOO...O...#
        #O...O.......O..O.#..O.....OOO..O.OO....O#..O....#
        #OO#...O.OO.........OO..O..O.#O...O.O.....#O.#O..#
        ##.O#......OO..#O#..O.....O#........O.O..OO....OO#
        ##.OO.....O.......O.#O..OOO.OO#O.OO.....O......O.#
        #O.O.O...O..O.OO.O.........O.#.O.#.....O.O....#..#
        #.....O.O.O.....#.#............#......#..O..#....#
        #..O........#......O.O..O.O.........O.O.....O..O.#
        #.O.#.O..OO....OO.......OO...O.O.....#O.OO.O.O...#
        #O.O...#OO..O....#........O#.#....O.OO...O..#O..O#
        #OO.....OO.#.....#...O#..#O.OO..OO#..#...O.O....O#
        ##O..O..O...OOOO#..O...............#....#O..O....#
        #.....O.#..........O....#..O##O...O..O.#O.....O.O#
        #O#...#..OOO#OO....O.O....#O.OO..O...O..O...O...O#
        ##.OO#.#..O...O.......#O.#.......O.O..O....O.##..#
        ##################################################
        
        ^>>v<>v>v^^v>vv^><v><vvv^><v>><^v^^<<v^v><<^>><v^^<^^<<v^>^v>vv^^^v<><^><<><<^<<^<v^v^^vvvv><<^^<>>^^vvv<vv<vvv<>>vvv^<><v><>v<^<^^v^<<v^vvv^<^v>v<>><^vv<>>^<v^^>vv^v<><<v^vv>>>><>vv<^^v<<vvvv^<^^v<>v>>>vv^^>>^v^^<<v<>vvv><v<v<<v<v<^^^<<v^v^v<<^<<^>v^vvv<>>^vvv<^<^<^>v^<<<vv>^><<<<><>^v<^<v^>>v<v^>^<>v>v>^<vvv>>><>^^v<v<^<v><>v<>^^>><v^<^<>><<<v>^^v<^^><vv<v<<<<^^>v^<^><>^><^^<v>vvvvv><^><<^v<><<^^vv^<>>vv<^<v^>^<v<^v>>^><>^v<<<>v<^vv>^v^<v^>>^<v>v>v><>v^><v^>v><<<<v<^v^^>v^v<<>v^^vvvv^>>^>>vv<^>>vv>><^<v<>^v>^>^<^<v^<<v>>vv>v<<^>^^<<v>v^<>>><v^^<^<<>^^^^v^^><^^v^v<^^^v^><^>^v><vvvv^^<^<<^<<^>v<^<vv<>>^v<<>v><vv<<>^^v>>><vv><v^v^^v^^<<<<^vv^vv<<>^<vv><v<>>^vv<>vv^<v<^<>^vv>v^^^vv^<^^v^<>^v^v><<<>^>v<v<<^<>>vv>><>^><v<vv>>v>^<^><<v^^v>^v^^>v<v<<<^^^<<<^v^<v<v^<<^<>^^<v><^vv<^>vv<<v<v<<^>^^><>^>>^^^^^<vv<>v>^<v>vv>>>>><><<^^>^^v<<^v<^<<<v<<<<^v<^<<^><>>vv^<<>^^>v>>v^v><^v>>v<v^<><v<<^>^^<^vv>^vv>>>^v<^^><^<>v<<<^^^><^^v^>vv^>v<v><^vv>^<>^v^>v>>v^^v^<<v<>^>^<><<v^<^v>vv<><<v>><^>v^^>^^><^
        v><^>^^^<>^<><<>v^^v^><>>>^v^v^<^><<^v>v<^>vvvv^<^<v^^^<>v<^vv<vv^<<>>>^>v<<v>><^>vv^>>>v^>>><>><^v^vv>>v<v<>vv>v^<^v^>v^vv>^v>><<>v^>v^>v<^v>><v^^<vvv><>^v^<^>^v<^>v<<<v<<^^^^v>v>^<<><><v^>>v<v>^<v<v<<^v<v^^<^v>v^^^<>^^v><>v^<v>v<v<>>vv^>^><>v^>>v>>^^<v><v<>v^^<v>>>>>v^v>>^>^v^<>^><^vv<^>vv<vvvv^>>v<^v^^v>^>>v>><>v<v^>>^^^<v<<^>>>>^<^^<><<<>^v<^<^><>>>vv<^>>>v<^^>>><<>>v^^^^^^v<v<<^>^v>^^^>><<><v^>^v^>v^^^^^>v^<>>^^^>^vv^^vv^>>>v><^><<><^v<>>^<>v^>>v^^><>v>v<v>^<v<<vv<vv^^v<>^>^<<v>^>vvv>v^>vvv<^<^v<>^<^v>^^v<v<>v^<^><^>v<v<<>^^vvv><><^^<>^^^vv<v^<^>>>>>v>^^><<^><<v^<<^<<>^>v<v^>vvvv>^v^^<^>>^<<v^>^^>vv><vvvv^v^>^^>>^>v^^vv>v<^<>v^<<v<v>v^>v>>^^><>>^v^<><>>^><>v><vv>>>>v^v<<v>^<^><>>>^<^^v>^<^^>><v><^^^vv>^^><^^<vvv<v>vvv<^^><v^<><vv^vvvv^>^<v<^<>>>>^v^vv>>^><>v^<<><^^<^>v<v<vv<^<<<^v<>^>v>v<<v<<v^^<^<^<><^<^^<v>v>>>^v<^<>^v>^>><>>vv^>v<<>^v>^>^<^<<<><>>v^<^<<<^>^v^<><<^v>>^^<v>v>^>^^<>^><<><>vv<vvv^><<<>^<<v>v^>^<<v^>v<v^><<vv^^^v^v><^^<^>v<v>^>^^<>>>v>v^><<<^>>v>><<v<v^><>^^<<vv<^v<
        v^>^v<<v<<v<^v<<v>^><^>^<^^^>vv>v<<vv<v><^v<>v<<>^>v<vv^><<v><v<<^vv^<<<v^^^<<v^<>>^^>v>^><^^^^>v<^<^>^^^<vv^v^<<<^^><<^v^<<^v^<v<vvvv^v<><^<<>v^^<v^v<vv^>>><^^<^v^v<vv^vv^<vvvvvv>v<v><^v>><^<vv^>^>>>^>>^v>v<vv^^vv<<<>><^v>v><<v<<v<^^v<^v>^^>v^>vvv>vvvv^<^v^><v<>>^v>^>v^^^<^v>v^^<>v>vvvv^^<v<^v^v<^><<<^^^^^vv<<<v>^v^<><<v>>><v>>^^<v>v^><><vv><^<vvv<^>>vv^><<<v^<^^<vv^^<^<v<><>v<<^<^^>><^^<>^>><vv<>^v><<<v>^^>^^v^v>vv^>^^>^^^>>v>v>>^^^>vv^^^<^^vv>>^>^v^<>v<<v<>v><^^>v<^v^v>>>vv^><>^>^^>vvv^v>^v>v^>>>v<<^>^^^<<><v^vv^>vv^>>><v<^vvv^<v>>v><<<v^v<^v<v<>^<^>><>>^vv<v^^>^>v^><vv^^v<^<v<<v^>vv>^>^v><<^v^^^>v><>^^^<vv<vv>^^^v>^^>>v><<><>>^v<vvv<>^^^><<>v<vv^^>^><<v<<^><<^^^^>>^^^^<v^v<>^><^<<>><^v<^<v>^>^<><^^v^<<<>v><<v>>v<^<<>v<vv<vv>>>>^><>>v>>^v^v>>v^^>^<><^^v^vvvv^vv>^^<><>><><^<v^<v>vv<v<>>>vvv^<>>>>>v>>vvv^^<^v<^v>v<>^><<>v<^>><>>v<^^<<^<^^<^v>>v<<^<vv<v^<>>^v^<v^v>v>vvvv^vv><>vvvv>^v>vv^^vv<>v><v><><v>>^^^<v>v<^^v<^^>^v><^<<<>v^><>><<>^<>>v^vvv^vv^><v>><^v<^<>^>^^><>^>v><<^^^><<<<<v>><
        ><>>v<<<v<^v^<v^^<>^>>vvv<<v^>^>v>^>><v^v^<v^<<vv<v<v>^v<^><v>><^vv^vvv^><<>><^>^^v^^>^<v>v>>>^^^^^>v^v<<^vvv>^<vv>v>^v^^^^><<v>^<<<<v<^v<^^>vv^v^<vv^v>^^>><v<<<^^^^^<<^v>>>>>>><<<>v<<><<<v>>>^<>^><<vvv^<^>v<v<^^><v>>v<<v^v^<<^vv<v>vvv<>v^>><^^v>><^vv>v^^^>^^<><<v<v<v<>>^>>^^v<><v><>vv<<v^^^v^>^<>^>^<^^>v>vv^<<<v>>><v^<>^<v^v<<<<^v>>>v><<>>v^^v^^v>>^v^^^>>vv>>^>vv><>vv>>v<^><<>><v^^>^>>v^<vv^^>^<^^>><^<>^<<<<<vv>><<^>^^>^<^<<<><>v<<^^v<>^v^v<><v^v>vv<><>>vvvvvv<v>^><>v<>><vvv<><vv^>>>>v<^^>v^v><>^<^v^^v^>v>v<^>^>v>>v<^^vvv^v<><^<^^<>v>v^^<v^>v>^^v>>^><>v^vv<<v<^>v^^<>vv>>^^^v><>^v>^v<<>>>^^^>^<><>^>v^vv>>v^vv<>>^^v>v>>>^>>v^>v^^^><v<^<>^<<>><v^><<<><<v<v><^>v><>^><^^v<>vvv<v>>v>v>v>^><<><vvv^<^<<v^v^vv^<>^^>>v^v^<v^v^v^vv^><>v^>v<>^^v^^><>>^^^>><>>v<v<^v><>>>v^<<^<^<vvv>><>v^vv^<<<<<^><^>v>vv<v>>v>>v>v>>^<v<^>v>><^<<^v>^>^v>^>><<>v^v<>^<<^^v<<>^v<vv<vv^>^<>vv<<<vv<>>v>^^<<<^<><^<<v>v>v^v<<v><v><^<v>v>vv>v>^vv<<<>v<>^^<v<<>v^^vv<>>^>v><vv^<>>vv><v^v>^<v><<^^v^v^v^^vv>^>v<<>vv<^<><>^^>>^
        ^<<^^<<><^^v<^v<<<^>v^<><<<^^v^>>>^<^<^>^<^v<^<^v<>>v<^v><>^^^^^>^<v>^^<^>>^^>><>^><>^<<^v>>^v^v^^<^<v^<<>>v>^v>><v<<v>>>>v^>^<<^<>><><>>>^^>^>>^v^>v^v>>>v<^<v^><<><^<^<v<<>>>v^^^<vv><>>^<<^v^v<^^^<>v>>^^<>^^v^<<><^^<><>v<^^v<^>^<^v>vvv>>>>>v^v<^v<^^^>^^<><>>v^><vv<^<<>>v^<v>>vv<^v<^vv>^<v<^<><<><^>>vv<>><<<>^v>>>^^^^>v<v>^^><<v<>vv>^<v<<^v>><v<>^v<v<v^<vv^<v^v<v<^<v>>>vv>^^<<<>^>^<<<<^<^v^<<v<<><^^><^>^^<>><<<^<<<>><v><<>v^<><><><<v>v^^>^^<>>>^^v<>>><^^v^^>>>^<^^>v<>v><^v^v<>v>^^>>^>><^vvv<<<^><>v^<<<^v>^><^vvv^^v<<^<^>^><<^v<>vv><vv>vv>v^>^<>><<><v><><v^>^v><><<>^<^^^v>^vv^>>>vvv^>v<>^<>>v^^v^^v^^<>v<v<<^^>>v<^<<>^<<>^>^^<vv<><^^<^v^v^<><<v>vv<v><<vvv^>>^^^^^>^>^^><^<v<>^><vv<^^^v^^>^<^v^<v<^<<>>v>^>v>^v>v^vv^<v^^v<<v<>^><>>><v<^v^^^vvvv^v<v^v<<vv<^<^<>>v^vv<<^^<><vvv<><><^^>v^>>^>^^<>>^<^v^>vv>>v^v<v<><><><^v^v><^^<v<^<<<v<<^>^<>v>v^^>>^>^<<^v>^<<<^><^<><v^><^v^>^>>vv<v^^>v<>v^v<>^><^>v>>^<<<^^v^^^^>vv^v><^^<>vvv^vv><>><vv>v>v<^<<><<^vv^>^>>v>><>^<^<>>v^<>>><><v>>^<<^>>><vv^<^>><v>v
        vv<>vv^vv^^v<>>>^vv>^>vvv^<<>v>^<>><v><^>^<><<v>^>v><<^vv^>><>v<^^^<^>><<^v<^^<><^>vv>v<vvv^<><<<^v>^>v<<^>^^<>><^<<>v<<vv^vv<^>^>^^<^<v^^^><>^v<v<vv<><<>vv>^<^^v><v^v<<<vvv^^<<vv^v<<<^v^><^vv<<^<^<^<^<v>^<vv<v>vvvvv^<>v>vv><v^<>^vvvv>^v^^^v>><>^v><^<^vvv^^<v<<^><v<<>^>^^>^>^v^<^vv^v^>>^<>>>^><>^^v>>vvv>>>>v<>v^>vv>v>>v>vv<><vv^v<><<<>vv^vv<^><><^<v><>v>v^>^<vv>>v^v>v^><<<^>^v^v<vvv<^<v><^>><>^^^<^vvv>>v^^v>v^v>^>><v<^>^<v^^^^v><^^vv<vvv><<>><<^<><<<>>><>v^vv^v<v>v<<v<v>>>>^v>><<>^^vv>^>v^<>v>^<<<^^>^^v<<vv^><>v>v>^^^><vv<<<^>>>vv^>>>>><>><^^^v>v^^v>v<>^<>><>v^^<<<vv>><<<^^^>v<^><^vv^^^<<v^<^v><v<><^v>vvv><<<^>>^v<>>v^<<>v^v<<^>>><<v<<v^^<^^vv^vv>v<v><^>^>>>^^v^vv^<>v^^^v>vv<<>v><^v>^>>^<v^v<<^vv^v^<><^v<^>>><<^>><<<>>>^>^^v^>v^v^>^^>^^>v<v<>>^v<^>vv>><^<>^v>^<v^>>v^>>^v><^<>v>^><<v<^<>^<v<>v><vv^<v^vv<^>^^^<^>v^<^v^<>v><<v^>^><<^<<<><v<vv<><<vv>^>^<^^vvv^^<>>v<^^>^<vv>vv<v^^^>^<^^>^>><>^>><^>>v<^v<v^<<^v<vv<>^>v>^vv>^><^v>vv<^<vv><v>v<v<v<>><><<^v^v>>^v^^v>v^v<><^^v>v<^>v><<^<vv^vv>>^
        <v>>^<v>^vv^<v>vv^<^>>><v<^>>v>>v<<vvv><^<^v^vv>^v^v^^^<v^>><><v>^>><<>><v><<^<>>><^<^v<<<><v<vv<<<<<<><>>>^v^>v^<^v^><v<v^^^^^vv<v<><^^><>v>>vv^>^>>^><>^><>^>v><vv>><>^vv>vv^vv<v^<<<>><^<^>^v^v<>v^<v<v>v^vv<^<^>vv<^v^^<<>^>>^><v>>>>v>>v<>><^<><>>^^v^>><<^^><>>^v^>^<><^v<<><^>v^<>vv<v<<<v^v^^v<v^<<^>><>>>v><<^<^^>^>^^>>>><<<<^>>>v<^<<^vv<vvv><^>>^<>>>^^>>><<<<vv<>v^^^^<>vv><>v^v^^^><><v^>><<v<>vv>^^>vvv^v^^<>>^^v^^>>^^v>>^<>^v>v>><^v><^>>v^v^>vv^v<^^v<><<<<<<<vv<>>>^^vv>v<<^v^>v^^>^^<v^<v^^v>>><<><^v^v^><<^>^<^<v^><<<^>^<^v^<<<v<^^>vv<<^^v>v^^<v<^>^^>^^^vvv>v^^^^>>v<<>>^<^<<v><^>>v>><^<<<>v>^v><^<<^^^v^>v<>>v<^v^v><v^v>^<>v><^v<>><>vvv^<v^>v^<v>^^^v<>>>>^v^<<vvvv>^>v^^<v<<^v<<>>vvv<<v>>><<^<^^vv<>vv<>^^>^vv^v<<^<>^^<^<^<vv<^v^v^^>>><vvv^v>>>^<>v<^v>><<><<>v>^^^^v<<>^<<<>^^<v^vv^<v^^^>>^v>^^>^v^<<^^<^>><>>^^<<vv>>v>><>>v^^^v<v^<>>>>>><<^^v<v<<v><><vv>^>^^<<v>^^<v<<v^v>><v^<^v<>^>^vv>>v^v<vv><^>vv^><^><>^^^><><>>>>v^^^<<<<>^<>><v^><^<<><^vvv>>v^<>^<^^v>v<>><>v>^<<v^<vv^v^^>^v><^<>><<v^<v
        ^vv<><v<v<<v<v<>>vv><>^><v^^<<^>>v^<<><<>^v^^^<v>^<^><^>>v^^>^^^^<>^v^>>v><^>vv^<^<><v^<>vv^>><<<<>vvv>>^<v^>v^^<<<<^v^<^<v>vv>^>v>^<^>>><v>><^<v<v<^<v<<^^^v<^><^v^<^^<v<vv><<^<<<<<vv<<><^v^<v><<^v^^<^v><v>v>^v^<v>v<v^>>>v<<<^<<>^>>vv^v^<v>^>v^><<>>v^v>>^v>^><v^v><>v^<<><vv<<v>^^^<>><v<v>>vv^>^<<vv>^<^<^v<^>><v^><v^^^v>><<<^v>v<<v^^vv>>^<v>^v>>>^vv^<v^^^>>><^>^>><vv>><v<^vvv><<><<^^>>>^v^^<v^vv<>^>^>^^v^v^<<<>vvv>>v<^<v<>^v<v<>^>^v>>>>vvvv>v^vv^^<^><v<v>v^<<^>^>><vv>^>><<^>v<^^v^^^>><>v^>v^^v^>>>>v>>^^<<<>^<^>^<^v^^^>v<<^<v><<<<^^v>>^>v<vvv>v<>v>>^^>^vv<^v<^>>v>v>^^>^v>>^<<v^>v>>v^^^>^v<>>^vv<<>>><^v^<^<v^^^<<><vv^>>><<><^><>>v>vv<v^<<><>v><^>^v>vv^>>>v<><v><^>v^><<<<<vvv^^>^v>^>v>vv>v^>v><><>vvvvvvv^<>>>^^<><vvv<vv<>^>v^^v<vv<v^>^><v>><v^vv^<^^^<v>>vvv^^v^^^>^>>v<^<<<<>vv^>v<v>>v><<<^v>^vv<>^<^<>>^>vv^vvv>v<<^<v>^^>^<^v^>>v^^^>vvv>v^>>><^vvvv^^>v^^>^><^<^<>^>>^>v<v<>v<>>v<v^vvv<v<><vv>^<^>^^^^^>v<^>>^vv^^v<v<><^<<^>vv>>v<^v<^>v>v<<^>v<<<^v><>><v><>>>>vvv^<<^<<v><>>>^>v^v><^><^<<>v>^vv
        v^vv<^<<>v><vv<^^><<v^<<>^<><<^<v><v<>v^>>><>>^^<vv><>>v<<>v><v<<<v>>^v<<^vvv>>^v^<^^^<^>v<v^v><v^>vv<v<vv^v>^>v<<>vv<<v>>>^v<v<^^<>>^<vv>^<><<>v^<vvv>^><^><^<>>>^^^><v<<><^v>>v<<^<>^>^^<v^^vv>>>v^v<^<^>v<v^>>^<><<^^>><<>v>^^>v>^<>v^v<^<^<<<><<v<v^^<vvv<v>>v><v<>^v>^v<v<^><>vv^>^^^v<^v>>v<><>^v<^^v>>^v^^>v^><<<vv<<>^<v<v<<v^^<<vv<v<^v<>vv>^>>>><<vv<vv<<<vvv<^>vv>>vv<><v<vv><v^v>^<v<v^<>^<^v<v>>>^<^>^vv<v<^><v<^^<>v>>>>>^v<v>>><^^v<><>vv^^v<v^v<^<<v<^^>v<>^>v>>>><v^<>^^<>^><^^v^vv><<<v<>>>^v^>v^^>^vv><><>v>vvvv^v>vv>>v<v><vv^<v^^<<v<vv^^^v>^>^v^^^<vv^>>>vvv^>><vvv<vvv^>><<vv^>v<<vv^^>vv>v<>>v>^^^>vv^^>><v>v>^>^vvv<^>vv>><<>^>v<><^v>^^vv>vv>v^<v>v<<><^<<<>^vv<<<v<>vvv<>v>^^^>>v<^^v<^<^<^vv>>^<^>^<^^<>><^^^vv<^^>v<v^<^><>v>^<v^^vv^^<><^^^^<>^v^<^<<<v><v>>>>>>>^^>^<>^>^>^<<v<>>^<^vv>>>>vvv>^<<<vv^>>v>>>>v>>v><>^v<^<^<v^^<^><^>^^<^>^^<v>>>v>>^<<v^<><>>>v><^vv><v^^>^v<v<>^v<v>^^><^v^^<<^<>^v<^>^>><<><vv^^<v>>><>>^<<><>v<^<<<^>>^v>>^^v<^<v<<v^<<>^>^v^<v><<^^>>v^v<>^v<>^<v<^<^<v<v><<<><<^>^^v>
        v>^v^<vv^^<^v>v>^<<<>>vv^^v<^<v^>^><^<^vvvvv^>v<<^<>^vv^v><v>>>v<<>^>v^<<>v^<^<^<<v^<v^><^v>^v^vv<v>vv>v<<<><^^^<<^><v^v>^v>><v><v<<<v<^<>vv^>>^>>v>>v>^v<<vvv><><v^>>^<v^<<^^v>>>v>v>v>^v>>v^>><^<><>^>><<<>^><^v<^^>v><<vvv<>^<>vv^>^v^^<^v><<v<^<vvv^<<v<^>vv>^v<<>v^^>v^>vv><vv>vv<<v^^vv<^<>>v>^^^>>>v^^^vv^><<v^<>vv^><<<<^v^>v^vv<<v^<<>^<>^^<<<^>v>>v>v><<^^><^<><><>^<>v<<^vv^<vvv<vvv>v^^><v>vv<>^^<><v>><v<v>^<<<v>>vv<><v<><>v<^>>>^v>><><v<^<^<>v<^^v<v^>vv^v^<>^vvv<vv<>v>v^v>v<^^v>>^>^>v>>>v>v<v^^<^v^<^v><<<><v^<^>^^vv^^<v>^v^^><>^<<>><^vvv<<vvvv<^^^<>v^>^><<v^v<v^v^<>^><<^<^^<<><<<^>v^>v<<v>^>>^v>v>vv<<>^vvv^v<v^vv>>v>^><<<>v<^<v>^<<<v^v><<^<^<>^^>^<^><^>vv^^^vv<>>v<vv^<^^vv^v^<^vvv><<^^v>><><<v<^^<<^v<>><>^v><<v>^<><>>^<^<><v^^><v<v>>><^^>v^>v><<^v>v>^<v><^<<^<v><<>vv<><^^<><v><<v^<<<>>v>><>^<<^>v>^<>^^><vv>^<^^v<><<^>>v^vv^<v>vv<>>>^<<^vv<<>^v>v<^v>><<>v<^^v<vv<^<>^^><^^v>^v>v<^^^<<><<<>^<><<^v^><<v<<><^<vv>v<>v><>v<vv<vv^<^v>v^>vvv>>>^<>>>v<v><><^>^>v^>v^v>^^vvv>vv>><<v^v^^^v<v^<>>>>^v
        ^^<^^^^<^>v^>^>^>>v<>>>><>>^^><v<v<<v<>v<^><<^^<<^>v^^^^>vv<^<<^^<vv^v^v<^<^>vv^><vv<><^vv<v^v^^<v>>^v>><<vvv<vv^><>^^vv><<^<<>>^v>^v^><v>>^>>>^^>v<<^>v^^^v<^^><^<^v^^v^v>vv<>^<v^vv^><>^^^<^<>><^>vv><^v<<^vvv><>^v<><>^<vvv<<v><vv<>><>^vv><^>^<>v<^^v<>><v<<v<v><><^<<>vv^^><>>^^><^<^v^<>^^^vv>v^v<><v^<v<>^^^>v^v<v^<><^<>^^v><<><^^<v^>v<^<vvvv<^>v^>^<<<<<v>^<<<>v<^>v^<^<>vv^^v>v><v>^><>>>^^>>v^><<>^v<v^>vv<<<<^<^v<>^<^^^^v<>v^<>^>>><vv>^>vv>^><^v<v<<>v<>><v<>^^>v^><^><vvv<<>^v>^^v<<>^^v^>><^<<v^^^v^<v><v^>vvv<>><v<^<><>^<>^<^><<v^v<<<^v><^^^^>>>^^>>^^^v>>><^>v<^<<<>v<^>^><v^<vv<vv^<><^v<>^vv>>^<><^vv^<><<<>v^vv^<^<^>>^v<>v>v<>>^v^<<^<v^v^><^vv>v^vv^<>^v>><^v^vv><^vv>vvv>>^vv>v>><v><v<>>v^v^>^><^^<<<v<^^<^v>><<^vvvv^^><<<v>^^v^^<<v>^><v^^^<v<^>>^<v^><v>v<>^><v>^v>>^>><v<^^<v^><v><<^vvv<^>^v<>v^>><>^>v>^^>><<<v>><^><>^v^^vv>v<>><>v<>v<^v>^^vv^>^v^^<^^<^<v^vvv>^<><>^vv<^vv><<>>><><v<<^^^<<^<^>v^>>vv<^vv><><v^v><><^vvv^<v<^<<>>^<v^><^^v^^><^^<^<<<>>><v^>vv<^^^^^<^><^><^^<v>v^>v>^^v<<v<vvv<v<v
        ^>>>^<^>^vv<>vv>^>vv^vv^<>^<^^^><vv<<^>><^^v^v<<<v<>>v<v<>vvvv<<^^<<vv^>>^>^v>^<<v^<>v^>^<vv>^v>v^><<vv><^^>^>^<>>v<vvvv^^>^>><><<^<v<v>^v>^vv<^^<v<>^^>>>^<>>^<>vvv><>v<>>^v^^<^<^^vv<^v^>^<<v<<><><<vv^vvv<v^v<>v^^<<<<v<>>v^>vv>v^><>>^<><<>>v<vv>><<<>>^><vvv^v<<<<<>vv>vv>^^v<^>><^>v^v>>^^^<v<>v<<v^<^v<<<v>v<><<>v>v<<v<vvv>vv^^<v><>>v^^<>v^>v^<v><<<<v^<>^<vv^>^^v<^^<>v^<><v<<v>^^v^><v<><^>v><>^>^^v^<v^v^vv>>vv^<<^<>^^^vv^v^^>v>v^>^^<<^v<<vv^<<<v^v^v<>>>v^>v>v<<<v<>v^^v><^>><<^^>v^vv><vv^^^^>^>^><><>>^<^^<vv^>>>^<<^<>>>>v<<><<v<>>vv<v<>>^>^^>>^>^vv<>^<<>vv>^><><^><vv><><^<^<v>^vvv>><>v><v^>>^<^>>vv<<><<<>v><<^<<<<^<<^>^^>^>^>>^<^<v>v<v<>^<<>^>>>^<^>^<v^^<>^>>vv<><vvvv^<<><<>>v<vv<v<vv<<><vv<^<^v^^<^v^<v>^<>><<<v><v>v<<><>>^>>v^^vvv<^<^<<>^<>^><^>vvvv^<><<>^v>v>>>v>>>v^>v>v^^^v^><<^<^vvv>v^<>>^>v<^^<<<^^><^v>^^<<v^<<<^<^>><<v<>^^<v^^><<^v>^v<^^v^><>^<^v><<^^^><<>>v<^><<>><^>v^<^^>^<<^>><>^<v^>>v><v>^^>>v>^^^v<^>><^><>>>v<^^>^^<^v^>^v>^<<^>^<v<^<^<>v^<>^v>v<>vv>^>>^<<vv>^><<<>><v^^v><<>>>vv
        vvvv^^v<>>v<vv^>v<<<<^^^>^^>^^>>>>^<v<^^>>><<v>^<>^>><<>v^>>>vv>^^>^<v^^>>^>^^<>>><^v>v>v^<^^v^>>^<^^^<v<<>>>v^v<v<^<v^v<^>^<<<>^v<<v^<^vvv<<<<<v>vv>^^^^^vv><<^^<^>^^<^^^v^><<<^><vvv<>>v^><^^v>^<>v><>>>><^>^v>^>v>^><>>^><<^><^v><<<>^vvv>^^>>^vvv>>^<>>^^>>>>^>v<^<<v^<>^^vv><v>vv>v>><<<<^v<^^>^vv<v^v^><vvv^^^<<><>><<v<v<>^>v<<<^<<<<^vv<^><v^<v>><><v>v<v>><><>>^>^v<<<<vv<^<<<<>v>vv<^v<>>^>v>>vv<v>^>v>^<><^^^^^v^>^<v^<<^><>>^vv<>vv^>v^>v>><<^>^<>>v>v<^vv^>^v<>>>vv^^<<vv<^^><v^>^<<>^<v>v><v><^><<v^^>v^>>v>>>vv^^^v<^<>^^^vv^vv<>^><^^^^^<>><><>vvv^>>v>^<<vv>v^^<>>>v<<<v^v<><<<v^>>>v^<>><>^<vvv>^>v>^v>^^<v>v<<>><^<^vv<><vv>^^vv^^<<v^>v>v>^vv^^><^^<<^vv<<v<^<v<vv><>v>v><<>^<^^<>vv<<<^v>vv^><^vvv<<>^v^><^^>^<><v^v^<>^>vv><v<vv^^vv<^v<<^>>vv^<^^vv><^^^vv^>v>v><>>v><v<<>^v^^<>v>^<<^<>v<><^v<>v^>>^^vv<<<<^^<v^^<v^<<<<<>^v^v<>^<v>v^>v^^<vv><>>vv>^v<^<<^>>>vvv>^>^>^v^<>^^^vv<vv<<>^^>^^><>^v^<^^>^v>>><vv^>^v<>vv<<^>^v<vv<vv>v<v><>^vvvv>^><<^^vv><<v<v<>>>v<<^<<v<><^<>^><><v<><^vv>>>>><<<^>^>v^<>^v<><^>
        v^<^<vvv^^^<v><v><<v^^<>v>^><v><<^>v>v>^^>^^><^>v>v<^<<>>v^<vvv<>><<>>^v^>>^><^v^>vv>^><^>^^<<v^^vvv<v^<v>><^>v^^><^>v^<><^>^^^<v>^^<v^^^><<<>^^^v<>^v<^^><v^^vv<vv><><>^>v^>^^v<^^vv<^<v><><v^><<^^<>>><>v<v>>>v^>^>^v^<^<v<^v>v>v<^^vvv><>^^>>>v^<v^<>^<<v^v^<>>>>>v<vv<>^v<>^>^<v>>v<^<>vv^<<<v<^^vv^>><^^>v^<v>v>>v<<<<<<v^vv^>v<^>>^^<^<^v<<<^>>^>^<v^^v>^^^>v^>v><v^>>^v>><<^>v<<^^^>^<^v<^vv<v>^v<^>>>^^vvv^<>>v<vv^vv>v<><v>>><^>><>><<^vv<>>^<v>v<>v<<<>^v>>^><>^<>>v^^<><>^><^<<vvv<<><>v>^v<<^^<v^>v^>^v<v>vvvv<<<<<^<v^>^<^^v<v>vvv^v^^^<v<>vv^v>^v>^^<<<<v<<<>^>><>vv^<>^<<>>v^>>v>^>vv<<v<>>^>v<<<<v>^^^>^>^^>v^>><v<<v><><<^<><>vv>^<>><^v>^>^>><v>^v>><v<^^<^<v>vvv^^v<<>^<^^^^>^>^^vv^v><><>v^^<>v<v<^vvv^v>vvv<v<^v^vv><^^<>>v^>>^<<<^^>v^<^<>^v^>>^^^><>v^^>^v<^<v<^v><>>>v^<><^v>><v<^^^<>>v<v^<<><^<<><vv><^<vv<><v^^v^v>>v<<^^vv<v^v<^<><<v^vv<<^<<v>><<><^>^^^<>v><<^>>>vvvvv<><<v^^^<^<>^><^^><^<><v>>>>v><v<>^v>^v^^>><v>>^v<>v<v<v^>^>v>>vvv<>>vv>v<<v^<^vv^v>^v>vv^^^>^v<vv^^^v>^<^^^^>^^^><^>>>vv<>>^^v^>^v>
        <^>><><<^^>^>v>v^^^><^^>>v><^vv>^<^v^<^<<><><^><v^v^<>^>v>vv>vv>v>>vvvv>^vv<<<^<v^^^^<<>><>v<v>vvv^>>v<<v<<<<>><v<^^<<<^v<vv>>>^v><^v<>><^>>>^v^<^v^^v><^<vvv>v<>^^<^v<>^>^<<^<>^^^^<v<vv^>^^v^vv>^<<><^>^v>^<^>^<<<<^>v^v<<<<v><<v^v<>v<<>v>v^<><v<<>^>^<<v^v^<v^^>><><<^><><>^^vv>^v^v>v^<^^^vv<^>^<>vv>^v^>vv<^<><<vv><^<v^^<<>>>^^<<^>^>><vvv><>v>>v<>^v<>>vv^^^<v^v>^<^>v>^<><vv^>^>>><^<^v>v^>^v>>^^<<v<>^><^^^^^^^<v<v<v^^>vv^>>^v>><>>>v<vv^>^<>^^^>^>v^<^vv^v<>v^^>vv<^<<<<v<<<<vv^^>v>v>v^<<v^<v<^v<^><<<v<>^>^>v>v<v^><^^v<>v^^<v>v><<>v>>><^v<vvv>v><v<^><v^<^v><<><v<>>v>^>^><<<v>>^v><v>v<v^<^>^>>^v>>^<<>v><^v<v>v^v^v^>v>><<vvv^>>><^v>><>>vvvv>^<^<^v^^^^^v^v^<<<^<^^vvv<><^>v<<vvv<^v<><>^>v<^^v>><<<^^v^<^vv^<<^<^v>^^vv^<<<^><<v^<^^>v^<v^><vv^^vv^>>^^v>^v>vv>><>v<^<v<vvv<>^^vvv>^>>^>>v<><<<^<<^<>v<><<^>>>>v<>>v>><<>^^v>>v>^<^>vv^v>^>v>^>v<<<>><>vv<<>vv<v>v<^>^><<^v^^<<<>>^<^vv>vvv^v^^<<v<^v<v<vv<<>>>><^^>>v>vv<vv^v>>v<<vv>v^>v^^>>>vvv<v<>>v>^^v^^<<^>>><v^>^>v<>v<>vv>^^v^>^^>v^><v>v^vv<>^v>>vvvvvv^<>
        vvvv<vv<>>>>><>^>^<^>>>^^>^>^v^vv<>^v<vvv<<v<<<^^<>vvv<^^<^>>^<^>vv>v<^^<vv^<>v><^<^>^><v^>>^v<^><<<<^vv^^v^>^<v^v<<>v^v>v><v<v>^<^>^^^v<v><>^v<^<v<^<v><>^>^>>><<>v<<^>^v<v^^v>>vvvv>v>^>vv<>>^>^<^<v<v^>v<^><<<>^>v^<>v<^^v<<<^v>>^^<^v>^^><>vv^><<v^><>>^^><v^^<<v^><<^>v^^^>^^>^^>>^v^<vv^<v>v<<^^>>>^v^^><^v^v^>>>^v>^>v<<v>^^>>^<>^><^><<v<<v^<>^^><<>vv<><<>vv^vvvvv^^>^<vv<^<<^^vv<^>^<^<<<^>>>><><<^<>v>v><^>>^<><^vv^v>^<><^^^v>><>^>^^v^^^><<><<^<vv>v^v^<v>^^^v>^<^><vvvv^^>^vv<>vv>><>>v><>^vv><>^v^<vv><<<^v>>>^^><^v<<<v^><^<<^>^v><>>^^^<>v>v<>>>^>>v><<vvv<^v<v^<^^><^^v^>>^>><><^>^v^>>>>^>vv<<<>vv^>vv^>vvv>>v>^><>vv>^^><^<^vv><v>vvv<^v^<<<<^<^^v><<<<><<vv^^^>^v^>^^<v>v^>v<>v<^^<><v^>v>v<<<>>^vvv>>><<^>vv>>^^<><^^>^v><v^>^^<^<^^<>v>vv<^>^^v>v<>>>>><>^v>>^<v>v>v>^^<^v^^<<v>v>vv<><<^vv<^<v<<^^v^>>^<>^v^>^>>^^><>>^><v^vv^^^v><>v><^>^<<^^^<>^v^^v^<v^v>>v^vvv<<v><>vv<^<<v<v<<>>^^vv<>><><>^<^v^vv>><vvv>vv<<^<v^>vvv<^<<>><>^<><^<^>^v<<<>^^v><^v<><v<v>v^v<>^<>>>^vv<^<v<>v^v^><vv^><>v>^><^>^>>>>v<>v<>^
        >^<>^v>><<vvv^>><<^^v>>v<<vv^>v>^<>>>v^<^v<>v<<v<vv^>>v>^<^><^^^<<^<>^v>><<<v^v<^>v><^>^^v<^v<><<^<^<^^<v<^<v>><v<<v^>^v<<>v^>v><><<<<v>^^v<<^v<^v<>^><>><><<>^><><>v<<>><>v^>vvv^vvv<><<>>^^^>><<>>v<>>>>v^v<^^<>>v<v>>>^<^^<>^>v>vv><^^<^>>^v>v>>v^<^<v>>^<><<>vv^^v>v<vv^^v<^><v<^>vvv>^>^<<>>^>^v<>^v^>><><^<^<^^>><vv^v^v<v>>>v>^^><>^<<^^v<^^>v^v^^>^<>v><<><<vv<><>vv>^>^vvv^<>>>^>v>^<<^>^<>>^^<<<><v^^^^^<<v^<vv<v<<^>v<>>>v>>v>>vv^><v>><^^<>v^^<^>>v^<<^><^>>>v>v>^v>>v^^v><<<^><^v<vv<>>vv>>v>>^<<<>^<^><vvvv^v^<<>v<v<>vv^<v<<>>>v>v>v>v>^<<vv<>v^^^v^^<^>>^<>^^v<>v>^<^v><<^<v>v<^^v<v>v<v><><^>^v><^<><^^^><<v<^v<^<v>^vv<v<<^<v>^>v>v><^><^<<v<v<>vv^>v^>v<>^<vv<^>><^<>>^v^><^v>><<<v<>>^^<v>>v><<v^vvv^v>v^^v>>>vv<v<>v<^^^<<>><v>v^<>vvv<><<<v><<vvvv>^^><^v><v<>>v^><><<^>><^>^v<^^v^v^^<>>v>^>^<^^>^^v^^<v^v>^<<^><^v>>^^<v^<>^vv>>vv><^^<^>v^^^><^>>v^>^^<v<vvv>v^>v>v>><<v>^>^^>^<^>vv>>v^^>>^>^v<v^^v^v^vv<><v<>v>>v<><v>^<^^^vvvv<^^<>>^v>v^v>^<^v>vv><<v>^^^v<^^<^^>^>^v<vvv<><<v^>v^<^><^<<<<v^^^^<><^<v<^^^>
        >vv<vv^<>v^<>vv>><<^v><v<>>v^^>vv^vv^^^vv><<><<<v^^v^<<^v^v^<v>><^<vv<v<^^v<vvv<v<<><<^<><>v<<>v><v^<>v<vv^^>^<^v^><>>>v^<>v<>^<><<>v>v>>>>vvv^>>>>>>^^v>v^<><v>^v>v<v>v<v>v^v>v>vv>vv^^<^vv^^^v><<<>^^<^^^><v><^^^^v<vvvvvvv<<><<>^v>>^<><v<^<>^<<<^>^^<><v^>^<v<^<^><v<^^v^<<<<^><><v^>v^>><v>>>>v><<^^<<<><<<>v>>>^^^v<<<v<>^v<^^^>^vv<>>><v^>^>>^<vv<>^>^^v><vvv^<<><v^<<v>v^>^>v>><><^vvv^<v<^><>v>>v<><^<>><^<^><v<<^^v<v^>^<>v><<^>>v^v<vv>v^><>v^>>><v<^^^<<^>v^>vv<^v<^<>>v^<<^v<<>>>^>>v^^^v<<<v<><v>>>>^v^<<<<^^>>v><^<^^>vv^>v^^>>><>>>v<>^v<>>>^<<><^^^>v><>v<>^<<>>v>v<v^<v<<v<^vv^<>^^<>v>v^^v^<^v>>^>>v><<^<<^vvv^^>>>><v>>><>v^<<<v>v^>>^<v>^v<v<^<<v>^^^v<v><v>>^^^<vv^<v<v>^^>v^<v>v^^>><>>><vv<v>v^v<^v<>v^>v<v>^>>>><<>^^>v>>^>><v<>>><<<<>v>^v><^^<><<<v>^<<^<^>><>^v^>^^^v^>^v^v^^^<<<<^^^^^v<<^>v>^<>^<^>^<vv^<>><<v<^v<>v<><<>v>><^<v<<^>^<>^<<^<^^<v>vv^v^<<<v^v^^v<>>>><v<^^<<^<<^<^^<v<^<^>vv^<>v^<>vv<^<<<<v<>>v^v>v<<v<v><v^<v>>^<^^^>^vv><<^v^^>^v^^^vvv><>v<^^>v>v<v<><v><v<^<^>^>vv>v<^v>vv>^<>^vv>>v<v
        ^v>><^<>^>v^^v>>>v<>v<<vv>v<<^v<><v<><^>v^^^<^v<^<^>>v^^<<<>v^^vv<vv<<v>>>v<^vv^v^v>^^<>><>>v<v<v<vv^><^v<>><<vv><^<>>v<<><v><>v^><<<<><^<>>v^^^>vv>^<^<v^vvvv<<<<^v<<<><vv^>^^><>v^vv<<<v^^v^v>^<v<><>v^<<<v>^v<<^><^v<>>>><^v>><v>^v<^<<v>v^^^<<v^>>^>><<><^^>^^vvv<<>>v<v>><>^<v<v<<>^vv><v><^<>^v^<^v<>^>^^^<><^v^<><<v^v<<>^^<v>v<<^>v^<^>>><v^^<<<>^^v><>^><><><<><>v^>^<v>^<<v<>>^<v<<v>v<<v>v^<>^<^<<><v<vv>>v><^^^^v>><<v<^vv<^><>^^^^^><><v<^vv<^v>v^v>^>><^^><^>^>>^^^><<>>^v>^v^>>v>v>>^><<<^<<v^<<vv>^<>>v<<^v^>vvvvv^<^>vv^vv^^v^v^<v>><v<^v<<>^>vv<<<><v>vv>^^>^^vv><^>v<<v<<v<v^<v<<^<<v^<><<^vv<><<>^>v^vvvv^<<<<v<<>><^>><<^>v><^>^v<<<^<^>v<^vvv^>^<>^>>^><<<<>^<v^>^^vv^^<<>>>v>><^>>^v^v^>v^<^<<v^vv<<^vv<v>>^>v<<>^>>^<<<><vv^vv>v^^><>^^<v<v>vv<v^<<v^>^<^^v>v<<>v><><v<v^^<^^v^^<<<^^^v><>^<<>^>v^v><^<^^vv^^><^v>>^<^<<^><^<<<>^^v^<><^<^^>^vvv^^v<<^<v>^<<<><^v^><vvvvv>^<^>^<^<v<^<v><vv>v^<>vv^><v<vv^^>^>v<vv<<>^<>v>><>>^>><<<^<vv<>^^^<<^<^<<>^v^<<<><^<>^vvvvv<<^^<<><v<>vvv<<<vvv^>v<v^vv^v^<><<^vvvv<>
        v<>><^v<v<>>vvv<<^v>><<^^>^<^^>>^<^<>>v>^<<>vvv<>v^<>v^^<<^v>v^><v^^v^v<>v<><^^^<>><^><^<<v^>v<>v<v^^v<>><>^>^v<v>^<^v<v^^^<^>vv^<v>>>^v>>v>^v^><v>>v<><^vv<v>v><v<v><^v<^^^<<<<vv^><^v><^<<<<>><<>><>^vv<>v^>^<^>^<><<^>^<<<<^^v>>^<>v><<<<v><<<><^<v^vv<v<<^<>>v<>vv^^<><^vv<<<^><>^<v<><>^^<<<<v^v<<^>v^<<^<vv^^>^vv<<><<v^^>v<<v^^>>^^<<v^<<^<<<^^vv<^>vv^^><><v><<<^v<^^^<<^^^^^vv>^><>><^>^<<v<^>v^<>^>^><^<^v>^<^<>v>^^^vv^v<vv<v><v^vv>^><>vv^^<>>vv^^v<<<<vv<v^>>>><v>v<<>>>v<v>>>vv>v>^^>><^^^^v<<v>^<<<>v><vv^>^>v^^^vv^<<^v<vv<^<v<^<^><<^><<^>>^<<v^^vvv>><v^v<<^<<<<<vv^v^<vv>v<^^<>>^>^>>><>^<^<^vv^>><^^<><v^<v<^>>>>v>^<v>><v^>^^v>><vvv<<v^<^^^<v>v^<^<>^v>v><<<v<<<vv>>v<v<v>v<v^^>><<<^>v<<<^^vv><v^^>v^v^^<>><<v><<<<^v<>^<<v<>^>v>vv<><<v<<<^^v^vv^vv^v^^>^^vvvv>>>v>>>>v^<vv^<^v^v>>>v<<vv>^^>^<vvv<>v<^^<vvv<vv^<^^^>^vvv^>v<^<^v<^><^<<^<><^v<><<>^<v>^^^<^^^>><v<>^<<>^^><v><^>^v>v><>>^^<><<vv^^>>v^>><v^><^<^^vv<v>^>><^<^<v<>><^<v>v<<>>^^^v>>>><v>v>vv^^<v><<v^><v>^^>^>v<>^^<vv><><v<^vv<>^<v^>v>>^^^<^^v
        """;

    [TestCase(TestInput1, "2028")]
    [TestCase(TestInput2, "10092")]
    public void Part1(string input, string expectedOutput)
    {
        var testOutput = Solution1(input);
        Console.WriteLine($"{nameof(Part1)} test result: {testOutput}");
        Assert.That(testOutput, Is.EqualTo(expectedOutput));
        
        // only executed if the test input worked
        var actualOutput = Solution1(Input);
        Console.WriteLine($"{nameof(Part1)} actual result: {actualOutput}");
    }

    [TestCase(TestInput2, "9021")]
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
        var grid =  input.Split("\n")
            .TakeWhile(line => !string.IsNullOrWhiteSpace(line))
            .Select(line => line.Trim().ToCharArray())
            .ToArray();

        int x = -1, y = -1;
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                if (grid[i][j] == '@')
                {
                    x = i;
                    y = j;
                    break;
                }
            }

            if (x != -1 && y != -1) break;
        }
        
        var movesArray = input.Split("\n")
            .Skip(grid.Length + 1)
            .Select(line => line.Trim())
            .ToArray();
        
        var moves = string.Join("", movesArray).ToCharArray();

        foreach (var move in moves)
        {
            var result  = Move1(grid, x, y, move);
            if (result.HasValue)
            {
                x = result.Value.newI;
                y = result.Value.newJ;
            }
        }

        long total = 0;
        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid[0].Length; j++)
            {
                if (grid[i][j] == 'O')
                {
                    total += 100*i + j;
                }
            }
        }

        return total.ToString();
    }

    private static (int newI, int newJ)? Move1(char[][] grid, int i, int j, char move)
    {
        var dir = move switch
        {
            '^' => (-1, 0),
            '>' => (0, 1),
            'v' => (1, 0),
            '<' => (0, -1),
            _ => throw new ArgumentOutOfRangeException(nameof(move), move, null)
        };

        var oldValue = grid[i][j];
        switch (grid[i + dir.Item1][j + dir.Item2])
        {
            case '#':
                return null;
            case '.':
                grid[i][j] = '.';
                grid[i + dir.Item1][j + dir.Item2] = oldValue;
                return (i+dir.Item1, j+dir.Item2);
            case 'O':
            {
                if (Move1(grid, i + dir.Item1, j + dir.Item2, move).HasValue)
                {
                    grid[i][j] = grid[i + dir.Item1][j + dir.Item2];
                    grid[i + dir.Item1][j + dir.Item2] = oldValue;
                    return (i+dir.Item1, j+dir.Item2);
                }

                return null;
            }
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private static string Solution2(string input)
    {
        var grid =  input.Split("\n")
            .TakeWhile(line => !string.IsNullOrWhiteSpace(line))
            .Select(line => line.Trim().ToCharArray())
            .Select(line => line.SelectMany(c =>
            {
                return c switch
                {
                    '#' => "##".ToCharArray(),
                    'O' => "[]".ToCharArray(),
                    '@' => "@.".ToCharArray(),
                    '.' => "..".ToCharArray(),
                    _ => throw new ArgumentOutOfRangeException()
                };
            }).ToArray())
            .ToArray();
        
        int x = -1, y = -1;
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                if (grid[i][j] == '@')
                {
                    x = i;
                    y = j;
                    break;
                }
            }

            if (x != -1 && y != -1) break;
        }

        var movesArray = input.Split("\n")
            .Skip(grid.Length + 1)
            .Select(line => line.Trim())
            .ToArray();
        
        var moves = string.Join("", movesArray).ToCharArray();
        
        foreach (var move in moves)
        {
            var result  = Move2(grid, x, y, move);
            
            if (result.HasValue)
            {
                x = result.Value.newI;
                y = result.Value.newJ;
            }
        }
        
        long total = 0;
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                if (grid[i][j] == '[')
                {
                    total += 100*i + j;
                }
            }
        }
        
        return total.ToString();
    }
    
    private static (int newI, int newJ)? Move2(char[][] grid, int i, int j, char move)
    {
        var dir = move switch
        {
            '^' => (-1, 0),
            '>' => (0, 1),
            'v' => (1, 0),
            '<' => (0, -1),
            _ => throw new ArgumentOutOfRangeException(nameof(move), move, null)
        };

        var oldValue = grid[i][j];
        switch (grid[i + dir.Item1][j + dir.Item2])
        {
            case '#':
                return null;
            case '.':
                grid[i][j] = '.';
                grid[i + dir.Item1][j + dir.Item2] = oldValue;
                return (i+dir.Item1, j+dir.Item2);
            case '[' when move is '<' or '>':
            case ']' when move is '<' or '>':
            {
                if (Move2(grid, i + dir.Item1, j + dir.Item2, move).HasValue)
                {
                    grid[i][j] = grid[i + dir.Item1][j + dir.Item2];
                    grid[i + dir.Item1][j + dir.Item2] = oldValue;
                    return (i+dir.Item1, j+dir.Item2);
                }

                return null;
            }
            case '[' when move is '^' or 'v':
            case ']' when move is '^' or 'v':
            {
                // we will simulate the move of both sides of the box in the copy of the original grid
                var newGrid = new char[grid.Length][];
                for (int x = 0; x < grid.Length; x++)
                {
                    newGrid[x] = new char[grid[0].Length];
                    for (int y = 0; y < grid[0].Length; y++)
                    {
                        newGrid[x][y] = grid[x][y];
                    }
                }

                (int x, int y) left, right;
                switch (grid[i + dir.Item1][j + dir.Item2])
                {
                    case '[':
                        left = (i, j);
                        right = (i, j + 1);
                        break;
                    case ']':
                        left = (i, j - 1);
                        right = (i, j);
                        break;
                    default:
                        throw new ArgumentException();
                }

                if (!Move2(newGrid, left.x + dir.Item1, left.y + dir.Item2, move).HasValue
                    || !Move2(newGrid, right.x + dir.Item1, right.y + dir.Item2, move).HasValue)
                {
                    // at least one side of the box can't be moved safely
                    return null;
                }
                
                _ = Move2(grid, left.x + dir.Item1, left.y + dir.Item2, move)!.Value;
                _ = Move2(grid, right.x + dir.Item1, right.y + dir.Item2, move)!.Value;
                
                grid[i + dir.Item1][j + dir.Item2] = oldValue;
                grid[i][j] = '.';
                return (i+dir.Item1, j+dir.Item2);
            }
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}