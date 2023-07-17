
//function calculateBMI() {
//    const weight = parseFloat(document.getElementById('weight').value);
//    const height = parseFloat(document.getElementById('height').value);

//    fetch(`/api/bmi/calculate?weight=${weight}&height=${height}`)
//        .then(response => response.json())
//        .then(result => {
//            const bmiResultDiv = document.getElementById('bmiResult');
//            bmiResultDiv.textContent = JSON.stringify(result);
//        })
//        .catch(error => console.error(error));
//}


function calculateBMI() {
    const weight = parseFloat(document.getElementById('weight').value);
    const height = parseFloat(document.getElementById('height').value);

    fetch(`/api/bmi/calculate?weight=${weight}&height=${height}`)
        .then(response => response.json())
        .then(result => {
            const bmiResultDiv = document.getElementById('bmiResult');
            bmiResultDiv.innerHTML = `BMI: ${result.BMI.toFixed(2)} <br> Description: ${result.Description}`;
        })
        .catch(error => console.error(error));
}

function addPatient() {
    const fullName = document.getElementById('fullName').value;
    const age = parseInt(document.getElementById('age').value);
    const height = parseFloat(document.getElementById('pat_height').value);
    const weight = parseFloat(document.getElementById('pat_weight').value);

    const data = {
        fullName: fullName,
        age: age,
        height: height,
        weight: weight
    };

    fetch('/api/bmi/addpatient', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    })
        .then(response => response.json())
        .then(result => {
            const patientResultDiv = document.getElementById('patientResult');
            patientResultDiv.textContent = JSON.stringify(result);
        })
        .catch(error => console.error(error));
}

function getBMIStatistics() {
    fetch('/api/bmi/statistics')
        .then(response => response.json())
        .then(data => {
            const statisticsResultDiv = document.getElementById('statisticsResult');
            statisticsResultDiv.innerHTML = '';

            for (const item of data) {
                const percentage = item.percentage.toFixed(2);
                const text = `${item.category}: ${percentage}%`;

                const p = document.createElement('p');
                p.textContent = text;
                statisticsResultDiv.appendChild(p);
            }
        })
        .catch(error => console.error(error));
}

function getAgeStatistics() {
    fetch('/api/bmi/statistics/age')
        .then(response => response.json())
        .then(data => {
            const ageStatisticsResultDiv = document.getElementById('ageStatisticsResult');
            ageStatisticsResultDiv.innerHTML = '';

            for (const item of data) {
                const percentage = item.percentage.toFixed(2);
                const text = `${item.agegroup}:${item.category} ${percentage}%`;

                const p = document.createElement('p');
                p.textContent = text;
                ageStatisticsResultDiv.appendChild(p);
            }
        })
        .catch(error => console.error(error));
}