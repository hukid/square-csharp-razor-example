# Payment processing example: Csharp

This sample demonstrates processing card payments with Square Connect API, using the
Square Connect C# client library.

## Setup

### Requirements

* Download and install [.net core 2.0](https://www.microsoft.com/net/download/macos)
* Signup a Square account from [Square website](https://squareup.com/signup)
* You have learned the basics from [Square Developer Docs](https://docs.connect.squareup.com/)

### Setup your square account

1. Login to [Square Dashboard](https://squareup.com/dashboard/)
2. Create some items from [Items Tab](https://squareup.com/dashboard/items/library)
3. Go to [Square Developer Portal](https://connect.squareup.com/apps) and create a new application.

### Build the project

After clone this sample project to local, open command line tool, from the project root directory, run:

    dotnet build

### Provide required credentials

Open './appsettings.json' and replace "AccessToken", "LocationId" and "ApplicationId" with the ids you get from your square application created in [Square Developer Portal](https://connect.squareup.com/apps).

If you're just testing things out, it's recommended that you use your _sandbox_
credentials for now. See
[this article](https://docs.connect.squareup.com/articles/using-sandbox/)
for more information on the API sandbox.

## Running the sample

Run the command from the project root directory:

    dotnet run

Then you can visit:

    http://localhost:5000

* You'll see your created items in square account listed in the page (If you are using sandbox, you'll see a dummy item)
* Click "Buy" button to go to checkout page, You can test a valid credit card transaction by providing the following card information in the form:

    * Card Number 4532 7597 3454 5858
    * Card CVV 111
    * Card Expiration (Any time in the future)
    * Card Postal Code (Any valid US postal code)

You can find more testing values in this [article](https://docs.connect.squareup.com/articles/using-sandbox)

**Note that if you are _not_ using your sandbox credentials and you enter _real_
credit card information, YOU WILL CHARGE THE CARD.**