class Book:
    
    # Initialize attributes
    title = ""
    author = ""
    year = 0
    isbn = ""

    def __init__(self, title, author, year, isbn): # Set attributes when created
        self.title = title
        self.author = author
        self.year = year
        self.isbn = isbn


    def __str__(self): # Return information on book
        return (f"{self.title}, by {self.author} ({self.year}) - ISBN: {self.isbn}")




class Library:

    books = {} # Initialize book dictionary

    def add_book(self, book): # Add a new book to the library

        if book.isbn in self.books: # Cannot create entries with identical ISBNs.
            print("A book with this ISBN already exists.")

        else:
            self.books[book.isbn] = book  # ISBN key
            print("Book added successfully!")

    def view_books(self): # Display all books in the library

        if not self.books: # If the library is empty, inform the user
            print("No books in the library.")

        else:
            for book in self.books.values():
                print(book) # Prints the string returned from __str__

    def update_book(self, isbn, **kwargs): # Update details of a book given its ISBN
    
        bookThatExists = self.books.get(isbn, None)

        if bookThatExists: # If ISBN matches a book in the dictionary, update
            book = self.books[isbn]
            for key, value in kwargs.items():
                if hasattr(book, key):
                    setattr(book, key, value)
            print("Book details updated successfully!")

    def delete_book(self, isbn): # Remove a book from the library using its ISBN

        bookThatExists = self.books.get(isbn, None)

        if bookThatExists:
            del self.books[isbn]
            print("Book deleted successfully!")
        else:
            print(f"No book found with ISBN {isbn}.")

    def search_book(self, isbn): # Retrieve a book's details by its ISBN

        bookThatExists = self.books.get(isbn, None)

        if bookThatExists:
            return bookThatExists
        else:
            print(f"No book found with ISBN {isbn}.")



while(True): # Loop program

    # Print the menu
    print("\nWelcome to the library Management System!")
    print("Please choose an option:")
    print("1. Add a new book")
    print("2. View all books")
    print("3. Update a book's details")
    print("4. Delete a book")
    print("5. Search for a book by ISBN")
    print("6. Exit")

    # Prompt the user to enter an integer (1 through 6)
    choice = input("Enter your choice: ")
    print("")


    if choice == "1": # Add a new book
        
        # Prompt user for book details
        title = input("Enter book title: ")
        author = input("Enter author name: ")
        year = input("Enter publication year: ")

        # Cancel the book creation if invalid (non-int) year is entered
        try:
            year = int(year)

        except ValueError:
            print("Year must be valid integer.")
            continue
        
        # Cancel the book creation if invalid ISBN is entered
        isbn = input("Enter ISBN number: ")

        if isbn.isalnum() and (len(isbn) == 10 or len(isbn) == 13): # Must be alphanumeric and either 10 or 13 characters
            new_book = Book(title, author, year, isbn)
            Library.add_book(Library, new_book)

        else:
            print("Invalid ISBN; Needs to be alphanumeric, and 10 or 13 characters long.")
            continue


    elif choice == "2": # View all books
        Library.view_books(Library)


    elif choice == "3": # Update a book's details
        
        isbn = input("Enter ISBN of the book to update: ") # Prompt user for ISBN to search for
        book = Library.search_book(Library, isbn)

        # If a book exists to update, prompt user for each value. Otherwise, tell them the book doesn't exist & cancel update
        if book:

            # Display book to be updated & prompt user for book values to update
            print(f"Current details: {book}")
            new_title = input("Enter new title (leave blank to keep current): ")
            new_author = input("Enter new author (leave blank to keep current): ")
            new_year = input("Enter new year (leave blank to keep current): ")

            update_fields = {} # Create dictionary object

            if new_title: # If a new title is entered, add it to the dictionary object
                update_fields['title'] = new_title

            if new_author: # If a new author is entered, add it to the dictionary object
                update_fields['author'] = new_author

            if new_year: # If a new year exists, verify it as an int. If it isn't an int, loop.
                
                try: 
                    update_fields['year'] = int(new_year)
                    
                except ValueError:
                    print("Year must be a valid integer.")
                    continue

            Library.update_book(Library, isbn, **update_fields) # If the program doesn't loop, update the book


    elif choice == "4": # Delete a book

        # Prompt ISBN of book to delete
        isbn = input("Enter ISBN of the book to delete: ")
        book = Library.delete_book(Library, isbn) 
        if book:
            print(book)


    elif choice == "5": # Search for a book by ISBN

        # Prompt ISBN of book to find
        isbn = input("Enter ISBN to search: ")
        book = Library.search_book(Library, isbn)
        if book:
            print(book)


    elif choice == "6": # Exit the program
        print("Exiting the program.")
        break


    else: # If the user inputs something other than a number 1 thru 6, print error & loop
        print("Invalid choice. Please try again.")
        