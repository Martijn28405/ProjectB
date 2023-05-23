
public class ManageShoppingCart
{
    public static void Start()
    {
        Console.CursorVisible = false;
        string prompt = "Shopping Cart Manager";
        string[] options = { "View Shopping Cart", "Empty Shopping Cart", "Return to Account Menu" };
        Menu shoppingcartmenu = new Menu(prompt, options);
        int Selectedindex = shoppingcartmenu.Run();
        switch (Selectedindex)
        {
            case 0:
                SnacksLogic shoppingcart = new SnacksLogic();
                shoppingcart.ViewShoppingCart();
                Console.WriteLine("Press any key to return to the menu");
                Console.ReadKey(true);
                Start();
                break;
            case 1:
                SnacksLogic shoppingcartempty = new SnacksLogic();
                shoppingcartempty.EmptyShoppingCart();
                Console.WriteLine("Shopping cart emptied");
                Console.WriteLine("Press any key to return to the menu");
                Console.ReadKey(true);
                Start();
                break;
            case 2:
                AccountMenu.Start();
                break;
        }
    }    
}