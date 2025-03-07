function confirmLogout() {
    let confirmation = confirm("Are you sure you want to log out?");
    if (confirmation) {
        window.location.href ="logingpage.html"; // Redirect to the login page
    }
}