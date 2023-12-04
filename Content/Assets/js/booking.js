$(document).ready(function () {
    $('#toggleButton').trigger('click');
    // You can also use a delay if needed
    // setTimeout(function() {
    //     $('#toggleButton').trigger('click');
    // }, 2000);
});
$(document).ready(function () {
    $('select').select2({
        minimumResultsForSearch: Infinity
    });
});
const steps = document.querySelectorAll('.profile-steps');
const nextButton = document.getElementById('nextBtn');
const previousButton = document.getElementById('previousBtn');
const contentSections = document.querySelectorAll('.content-section');

let currentStep = 0;

const updateStep = () => {
    steps.forEach((step, index) => {
        if (index === currentStep) {
            step.classList.add('active');
            step.classList.remove('active-green');
        } else if (index < currentStep) {
            step.classList.remove('active');
            step.classList.add('active-green');
        } else {
            step.classList.remove('active', 'active-green');
        }
    });

    contentSections.forEach((section, index) => {
        if (index === currentStep) {
            section.style.display = 'block';
        } else {
            section.style.display = 'none';
        }
    });

    // Check if currentStep is 1 to hide previousBtn
    if (currentStep === 0) {
        previousButton.style.display = 'none';
    } else {
        previousButton.style.display = 'inline'; // Or 'block', depending on the button type
    }
    // Change text of nextBtn when at the last step and update its type
    if (currentStep === steps.length - 1) {
        nextButton.textContent = 'Save Changes'; // Change the text to 'Save'
        nextButton.setAttribute('type', 'submit'); // Change the type to 'submit'
    } else {
        nextButton.textContent = 'Next'; // Change the text to 'Next'
        nextButton.setAttribute('type', ''); // Change the type to 'button'
    }

};

nextButton.addEventListener('click', () => {
    if (currentStep < steps.length - 1) {
        currentStep++;
        updateStep();
    }
});

previousButton.addEventListener('click', () => {
    if (currentStep > 0) {
        currentStep--;
        updateStep();
    }
});

// Initial state setup
updateStep();