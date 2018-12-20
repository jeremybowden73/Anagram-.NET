
// Pressing ENTER when the cursor is in the text area field causes the submit button to be activated
//
// get the input field
var input = document.getElementById("text-input-area");
// execute the function when the ENTER key is pressed down
input.addEventListener("keydown", function (event) {
    // keyCode 13 is the "Enter" key
    if (event.keyCode === 13) {
        // cancel the default action (of creating new line in text area box) because it looks crap
        event.preventDefault();
        // trigger the button element with a (simulated) mouse click
        document.getElementById("submit-button").click();
    }
});
