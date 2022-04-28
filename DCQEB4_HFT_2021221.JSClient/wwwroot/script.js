let departments = [];
let connection = null;
getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:50620/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("DepartmentCreated", (user, message) => {
        getdata();
    });

    connection.on("DepartmentDeleted", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();
}

async function getdata() {
    await fetch('http://localhost:50620/department')
        .then(x => x.json())
        .then(y => {
            departments = y;
            console.log(departments);
            display();
        });
}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

function display() {
    document.getElementById('resultarea').innerHTML = "";
    departments.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>"
            + t.departmentName + "</td><td>" +
            `<button type="button" onclick="remove(${t.id})">Delete</button>`
            + "</td></tr>";
    });
}

function remove(id) {
    fetch('http://localhost:50620/department/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null})
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function create() {
    let name = document.getElementById('departmentname').value;
    fetch('http://localhost:50620/department', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { departmentName: name }),
    })
        .then(response => response)
        .then(data =>
        {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}