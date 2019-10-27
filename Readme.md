## To Run:

If you cannot run, try installing Visual Studio 2019 OR .Net Core 2.2 SDK. If it still doesn't work, also install .Net Core 3.0 SDK.
This project makes use of C# 8 syntax, particularly with the new switch statement found in IOHandler.cs.

## Assumptions

* Users will input player names and hand one at a time
* Names can be anything as long as it's not an empty string
* Cards will be a white space separated input 
    * inputs are in the form of {A}{D} (Ace of Diamonds), with the rank as the first letter and the suit as the second letter
        * ex) AD 5S 6H AS KC (lower case or upper case)
* There needs to be a minimum of 2 users to evaluate the winners
* There are no restrictions on number of ranks or suits (Thinking here is there can be more than one deck, so multiple AD AD is valid)
* No checks on duplicate player names 
