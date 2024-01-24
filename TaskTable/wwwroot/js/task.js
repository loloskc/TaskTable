
const url = 'api/mytasks';
const urlStatus = 'api/status';

let tasks = [];
var statusMap = new Map();

function getItems() {

    fetch(urlStatus)
        .then(response => response.json())
        .then(data => getStatus(data))
        .catch(error => console.error('', error));

    fetch(url)
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => console.error('Unable to get items.', error));
}

function getStatus(data) {
    data.forEach(item => {
        statusMap.set(item.statusId, item.statusName);
    })
}

function _displayItems(data) {
    const tBody = document.getElementById('todos');
    tBody.innerHTML = '';

    data.forEach(item => {
        let tr = tBody.insertRow();

        let tdID = tr.insertCell(0);
        let id = document.createTextNode(item.id);
        tdID.appendChild(id)

        let tdName = tr.insertCell(1);
        let name = document.createTextNode(item.name);
        tdName.appendChild(name);

        let tdDis = tr.insertCell(2);
        let disc = document.createTextNode(item.description)
        tdDis.appendChild(disc);

        let tdStatus = tr.insertCell(3);
        let status1 = document.createTextNode(statusMap.get(item.statusId)); // idk sometimes "undefined"
        tdStatus.appendChild(status1);

        
    });

    tasks = data;

}