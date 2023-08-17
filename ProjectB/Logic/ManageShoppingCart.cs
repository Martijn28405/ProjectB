public class ManageShoppingCart
{
    public static void Start()
    {
        Console.CursorVisible = false;
        string prompt = "Manage Shopping Cart Menu";
        string[] options = { "View Shopping Cart", "Empty Shopping Cart", "View Seats cart", "Empty Seats Cart", "Return to Menu" };
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
                ReservationsLogic logic = new ReservationsLogic();
                logic.ShowUserSeats();
                Console.WriteLine("Press any key to return to the menu");
                Console.ReadKey(true);
                Start();
                break;
            case 3:
                if (ReservationsLogic._carts == null)
                {
                    Console.WriteLine("Cart was already empty");
                    Console.WriteLine("Press any key to return to the menu");
                    Console.ReadKey(true);
                    Start();
                    break;
                }
                else
                {
                    ReservationsLogic.EmptySeatCarts();
                    Console.WriteLine("Seats cart emptied");
                    Console.WriteLine("Press any key to return to the menu");
                    Console.ReadKey(true);
                    Start();
                    break;
                }
            case 4:
                AccountMenu.Start();
                break;
        }
    }
}
