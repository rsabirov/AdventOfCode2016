namespace AdventOfCode2016.Day19
{
    public sealed class Elf
    {
        public int Number { get; }
        public int Presents { get; set; }
        public Elf Next { get; set; }
        public Elf Prev { get; set; }

        public Elf(int number, int presents)
        {
            Number = number;
            Presents = presents;
        }
    }
}