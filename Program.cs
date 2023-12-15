using System;
using Visual_Art_Galary.dao;
using Visual_Art_Galary.entity;
using Visual_Art_Galary.Exceptions;
using Visual_Art_Galary.Services;

public class MainModule
{
    
    public static void Main(string[] args)
    {
        IVirtualArtGalleryServices service = new VirtualArtGalleryServices();
        MainModule obj = new MainModule();
        /*List<Artwork> artworkList = service.BrowseArtwork();
        foreach (Artwork artwork in artworkList )
        {
            Console.WriteLine(artwork);
            Console.WriteLine();
        }*/
        //service.BrowseArtwork();
        while (true)
        {
            Console.WriteLine("VIRTUAL ART GALLERY");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.WriteLine("3. Exit");
            Console.WriteLine("Please enter your choice : ");
            //Console.WriteLine("3. Browse Artwork");
            //Console.WriteLine("4. Search Artwork");
            //Console.WriteLine("5. View Galleries");
            //Console.WriteLine("6. User Profile");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("");
                    Console.WriteLine("Enter Username and Password");
                    string username = Console.ReadLine();
                    string password = Console.ReadLine();
                    bool LoginStatus = service.Login(username, password);
                    if (LoginStatus)
                    {
                        Console.WriteLine("Login SuccessFull");
                        obj.AfterLogin(username);
                    }
                    else
                    {
                        throw new UserNotFoundException();
                    }
                    break;

                case "2":
                    Console.WriteLine("");
                    bool RegistrationStatus = service.Register();
                    break;

                case "3":
                    Console.WriteLine("Exiting the art gallery. Goodbye!");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                    break;
            }
        }

    }
    public void AfterLogin(string username)
    {
        IVirtualArtGalleryServices service = new VirtualArtGalleryServices();
        Console.WriteLine("-------Welcome to Virtual Art Gallary-------");
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Enter Your Choice");
            Console.WriteLine("1. Browse Artwork");
            Console.WriteLine("2. View Galleries");
            Console.WriteLine("3. View Your Profile");
            Console.WriteLine("4. Logout");
            Console.WriteLine();
            Console.WriteLine("Please enter your choice : ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case"1":
                    List<Artwork> artworkList = service.BrowseArtwork();
                    if(artworkList != null)
                    {
                        foreach (Artwork artwork in artworkList)
                        {
                            Console.WriteLine(artwork);
                            Console.WriteLine();
                        }
                    }
                    break;
                case "2":
                    List<Gallery> galleryList = service.ViewGalleries();
                    if (galleryList != null)
                    {
                        foreach (Gallery gallery in galleryList)
                        {
                            Console.WriteLine(gallery);
                            Console.WriteLine();
                        }
                    }
                    break;
                case "3":
                    Users userProfile = service.GetUserProfile(username);

                    if (userProfile != null)
                    {
                        Console.WriteLine(userProfile);
                    }
                    break;
                case "4":
                    if (service.Logout())
                    {
                        Console.WriteLine("Logout successful.");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Logout failed. Please try again.");
                        break;
                    }
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                    break;
            }
        }
    }

}



 /*case "3":
    Console.WriteLine("Selected: Browse Artwork");
    // Call method
    break;

case "4":
    Console.WriteLine("Selected: Search Artwork");
    // Call method
    break;

case "5":
    Console.WriteLine("Selected: View Galleries");
    // Call method
    break;

case "6":
    Console.WriteLine("Selected: User Profile");
    // Call method
    break;*/



/*        try
        {

            VirtualArtGalleryDAO artGalleryDAO = new VirtualArtGalleryDAO();

            // Example usage of methods
            Console.WriteLine("Virtual Art Gallery Main Module");

            // Add Artwork
            Artwork newArtwork = new Artwork { Title = "Beautiful Sunset", Description = "A scenic view of a sunset" };
            bool artworkAdded = artGalleryDAO.AddArtwork(newArtwork);
            Console.WriteLine($"Artwork Added: {artworkAdded}");

                            // Add User (assuming you have a User class)
                            Users newUser = new Users { UserId = 1, UserName = "john_doe" };
                            //artGalleryDAO.AddUser(newUser);

            // Add Artwork to User's Favorites
            bool addedToFavorite = artGalleryDAO.AddArtworkToFavorite(newUser.UserId, newArtwork.ArtworkID);
            Console.WriteLine($"Added to Favorites: {addedToFavorite}");

            // Get User's Favorite Artworks
            var favoriteArtworks = artGalleryDAO.GetUserFavoriteArtworks(newUser.UserId);
            Console.WriteLine("User's Favorite Artworks:");
            foreach (var artwork in favoriteArtworks)
            {
                Console.WriteLine($"- {artwork.Title}");
            }

            // Search Artworks
            var searchResults = artGalleryDAO.SearchArtworks("Sunset");
            Console.WriteLine("Search Results:");
            foreach (var result in searchResults)
            {
                Console.WriteLine($"- {result.Title}");
            }

            // Update Artwork
            newArtwork.Description = "A beautiful painting of a sunset";
            bool artworkUpdated = artGalleryDAO.UpdateArtwork(newArtwork);
            Console.WriteLine($"Artwork Updated: {artworkUpdated}");

            // Remove Artwork
            bool artworkRemoved = artGalleryDAO.RemoveArtwork(newArtwork.ArtworkID);
            Console.WriteLine($"Artwork Removed: {artworkRemoved}");

            // Remove Artwork from User's Favorites
            bool removedFromFavorite = artGalleryDAO.RemoveArtworkFromFavorite(newUser.UserId, newArtwork.ArtworkID);
            Console.WriteLine($"Removed from Favorites: {removedFromFavorite}");

        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error Occured");
        }
            Console.ReadLine(); // Keep console window open until user presses Enter
*/






/*// Instantiate the DAO class
        VirtualArtGalleryDAO artGalleryDAO = new VirtualArtGalleryDAO();

        try
        {
            // Adding an artwork
            Artwork artwork1 = new Artwork { Title = "Mona Lisa", Description = "Famous painting", CreationDate = DateTime.Now, medium = "Oil", ImageURL = "monalisa.jpg" };
            artGalleryDAO.addArtwork(artwork1);

            // Attempting to retrieve an artwork by ID
            Artwork retrievedArtwork = artGalleryDAO.getArtworkByID(1);
            Console.WriteLine("Retrieved Artwork: " + retrievedArtwork.Title);

            // Attempting to retrieve a non-existing artwork by ID
            Artwork nonExistingArtwork = artGalleryDAO.getArtworkByID(100);
            Console.WriteLine("Retrieved Artwork: " + nonExistingArtwork.Title);
        }
        catch (ArtWorkNotFoundException ex)
        {
            Console.WriteLine($"Artwork not found with ID: ");
        }
        catch (Exception ex)
        {
            // Catch any other unexpected exceptions
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
        finally
        {
            
        }*/