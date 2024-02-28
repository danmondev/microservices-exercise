using Common.Dtos;

namespace BooksService.Repository
{
    public static class Books
    {
        public static List<BookDto> List = new()
        {
            new BookDto(1, "Clean Code: A Handbook of Agile Software Crafstmanship; Robert C. Martin", "Even bad code can function. But if code isn’t clean, it can bring a development organization to its knees. Every year, countless hours and significant resources are lost because of poorly written code. But it doesn’t have to be that way.", "https://www.amazon.com/Clean-Code-Handbook-Software-Craftsmanship/dp/0132350882"),
            new BookDto(2, "Mythical Man-Month, The: Essays on Software Engineering; Frederick Brooks Jr.", "Few books on software project management have been as influential and timeless as The Mythical Man-Month. With a blend of software engineering facts and thought-provoking opinions, Fred Brooks offers insight for anyone managing complex projects", "https://www.amazon.com/Mythical-Man-Month-Software-Engineering-Anniversary/dp/0201835959"),
            new BookDto(3, "The Pragmatic Programmer, 20th Anniversary Edition; David Thomas, Andrew Hunt", "For twenty years, the lessons from The Pragmatic Programmer have helped a generation of programmers examine the very essence of software development, independent of any particular language, framework, or methodology.", "https://pragprog.com/titles/tpp20/the-pragmatic-programmer-20th-anniversary-edition/"),
            new BookDto(4, "Code Complete: A Practical Handbook of Software Construction; Steve McConnell", "Widely considered one of the best practical guides to programming, Steve McConnell’s original code complete has been helping developers write better software for more than a decade."),
            new BookDto(5, "Grokking Algorithms: An Illustrated Guide for Programmers and Other Curious People; Aditya Bhargava", "Grokking Algorithms is a fully illustrated, friendly guide that teaches you how to apply common algorithms to the practical problems you face every day as a programmer.")
        };
    }
}
