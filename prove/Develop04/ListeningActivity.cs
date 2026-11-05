using System;
using System.Collections.Generic;

class ListingActivity : Activity
{
    private List<string> _listingPrompts;
    private List<string> _entries;

    public ListingActivity() : base("Listing Activity", "...")
    {
        // Populates listing prompts and initializes the entries collection list.
    }

    public void PromptUser()
    {
        // Selects a unique random listing prompt and gives a countdown to start thinking.
    }

    public string GetUserInput()
    {
        // Reads lines of items entered by the user during the active listing duration.
    }

    public int GetEntryQuantity()
    {
        // Returns the total count of valid items entered by the user.
    }
}