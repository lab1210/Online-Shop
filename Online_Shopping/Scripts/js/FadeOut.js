// Wait for the document to be ready
$(document).ready(function () {
    // Check if the message element exists
    var messageElement = $("#messageAlert");
    if (messageElement.length) {
        // Show the message element
        messageElement.fadeIn();

        // Set a timeout to hide the message after 2 seconds (2000 milliseconds)
        setTimeout(function () {
            messageElement.fadeOut();
        }, 2000);
    }
});
