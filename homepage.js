function toggleNav() {
    var nav = document.getElementById('verticalNav');
    var content = document.getElementById('mainContent');
    nav.classList.toggle('active');
    content.classList.toggle('shifted');
  }