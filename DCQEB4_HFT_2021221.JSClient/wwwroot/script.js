let departments = [];

fetch('http://localhost:50620/department')
    .then(x => x.json())
    .then(y => {
        departments = y;
        console.log(departments);
        display();
    });


function display() {
    departments.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>"
            + t.departmentName + "</td></tr>";
    });
}

function create() {
    let name = document.getElementById('departmentname').value;
    fetch('http://localhost:50620/department', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { departmentName: name }),
    })
        .then(response => response.json())
        .then(data => { console.log('Success:', data); })
        .catch((error) => { console.error('Error:', error); });
    display();
}