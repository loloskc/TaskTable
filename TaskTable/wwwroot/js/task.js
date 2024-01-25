
const url = 'api/mytasks';
const urlStatus = 'api/status';
const statusMap = new Map();

let tasks = [];
let status = [];



function getItems() {

    fetch(url)
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => console.error('Unable to get items.', error));
}

function getStatus(callback) {
    
    fetch(urlStatus)
        .then(response => response.json())
        .then((data) => {
            callback(data);
        })
        .catch(error => console.error('', error));
}

function getName(data) {
    data.forEach(item => {
        statusMap.set(item.statusId, item.statusName);
    })
    getItems();

}



function _displayItems(data) {
    const tBody = document.getElementById('todos');
    tBody.innerHTML = '';
    
    data.forEach(item => {
        let tr = tBody.insertRow();
        tr.id = item.id;
        tr.onclick = (event) => {
            choiceLine(item.id);
        }
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

        let tdChoice = tr.insertCell(4);
        let radio = document.createElement('input');
        radio.type = 'radio';
        radio.name = 'task';
        tdChoice.appendChild(radio);
        
    });

    tasks = data;
}


function deleteItem() {
    let id = chLine.id;
    if (chLine.id != null) {
        chLine = {
            id: null
        }
        fetch(`${url}/${id}`, {
            method: 'DELETE'
        })
            .then(() => getItems())
            .catch(error => console.error('Unable to delete item.', error));
    }
    else {
        alert('Данные не выбраны');
    }
}

function updateItem() {
   
    const Task = {
        id: Number(document.getElementById('edit-id').value),
        name: document.getElementById('edit-name').value,
        description: document.getElementById('edit-desc').value,
        statusId: Number(document.getElementById('status-select-edit').value),
        status:null
    }
    console.log(Task);

    fetch(`${url}/${Number(Task.id)}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(Task)
    })
        .then(() => getItems())
        .catch(error => console.error('Unable to update item', error));
    closeEditForm();
}