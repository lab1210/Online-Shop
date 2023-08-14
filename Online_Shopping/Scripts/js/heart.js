document.addEventListener('DOMContentLoaded', function () {
    const heartIcons = document.querySelectorAll('[name^="heartIconOutline_"], [name^="heartIconFilled_"]');

    heartIcons.forEach(icon => {
        icon.addEventListener('click', function () {
            const isFilled = icon.classList.contains('bi-heart-fill');
            if (isFilled) {
                icon.style.display = 'none';
                icon.previousElementSibling.style.display = 'block';
            } else {
                icon.style.display = 'none';
                icon.nextElementSibling.style.display = 'block';
            }
        });
    });
});
