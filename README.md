# Virtual Pet Age Tracker

## About
Virtual pet toys are handheld games that task the player with caring for and raising a digital pet or creature. Though most iterations have a set lifespan for these pets, some will allow you to keep the game running for as long as you can keep your pet happy and healthy.

An example of the above are the Giga Pets virtual pets, which were rebooted in 2018. Unless their health score drops to zero, these pets can live forever. However, the age counter will stop increasing after 100 years (or 250 years for the more advanced models).

That means you will lose the ability to track your pet's age after approximately three months (as most pets display days passed in years).

This application is designed to help log and keep track of your pets' ages. Input your pet's name, type, and birthday to save it to your computer. The application will then display your pet's age when prompted.

Because the app follows the traditional passage of time (days = days, years = years), it can be used to keep track of non-virtual pets as well. Some sample pets have been included to demonstrate this feature and can be removed if so desired.

## Initial Setup
- Download the ZIP file that corresponds with your operating system.
    - MacOS Apple Silicon computers: Use __VPAT_macos-arm64__
    - MacOS Intel computers: Use __VPAT_macos-x64__
    - Windows: try using __VPAT_win-x86__ first, then __VPAT_win-x64__ if the former behaves inappropriately
- UnZIP the file and place its contents wherever you keep your favorite applications. _(ex. Documents, Desktop, Applications, OneDrive, etc.)_ __Make sure to keep the file structure intact.__
- Double click the script file, named __VPAT-Launcher.__ This is what launches the program.
    - The __VPAT_win-x86__ version does not use a script file to launch. Double click the __.exe__ file to launch the program.
- Create a shortcut to the __VPAT-Launcher__ and place it anywhere you'd like for easy access.
    - To create a shortcut, right click the __VPAT-Launcher__ file and select _Make Alias_ on MacOS or _Create Shortcut_ on Windows.
    - The __VPAT_win-x86__ version does not use a script file to launch. Create a shortcut that points to the __.exe__ file.

### MacOS Users
While trying to launch the app, you will encounter several security warnings that instruct you to contact the app developer. Please refer to the support article below on how to resolve these warnings.

[https://support.apple.com/guide/mac-help/apple-cant-check-app-for-malicious-software-mchleab3a043/mac](url)

I tested the "Open Anyway" method in the "Privacy & Security" settings and that worked for me, though several files require individual approval.  I apologize for this inconvenience.

## Using the App:
The application has three core functions: _List current pets, add a pet,_ and _remove a pet._ Navigation through the prompts and menus is done with the keyboard.

### Current Pets
Selecting this menu generates a list of all pets saved in the application. Pet ages are calculated at this stage to ensure that they are always accurate.

### Add Pet
This menu will guide you through the process of adding a new pet to the application. You will need to know your pet's name, type, and date/time of birth. Pet type can represent whatever you'd like - brand, species, color, breed, etc. If the pet's birthday is the same day that it is being added to the tracker, you can indicate as such to save yourself some typing :)

### Remove Pet
Verify the name of the pet you wish to delete by visiting the __Current Pets__ menu first - you will need to know the exact name you entered when you previously added the pet! After navigating to the __Remove Pet__ menu, you will be prompted to type in the name of the pet you wish to delete. Do so and confirm that you want to delete the pet.

Pet deletion is __PERMENANT__ and cannot be undone!

### Exit

Select this menu option to exit the application.

## Technologies Used:
- C#/.NET
- Visual Studio
- Command Line Interface (Terminal for MacOS, Command Prompt for Windows)
- Shell script (on MacOS)
- Batch script (on Windows)
