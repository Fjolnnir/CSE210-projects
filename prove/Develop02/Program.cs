


class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        FileHandler fileHandler = new FileHandler();
        Menu menu = new Menu();

        menu.DisplayMenu(journal, promptGenerator, fileHandler);
    }
}