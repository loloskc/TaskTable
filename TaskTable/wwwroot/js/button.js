

function showAddForm(id) {
    document.getElementById('addTask').style.display = 'block';
    loadOptionAdd(id);
}

function closeAddForm() {
    document.getElementById('addTask').style.display = 'none';
}

function showEditForm(id) {
    if (chLine.id != null) {
        document.getElementById('editTask').style.display = 'block';
        loadOptionAdd(id);
        const task = tasks.find(item => item.id === Number(chLine.id));
        console.log(task);
        document.getElementById('edit-id').value = task.id;
        document.getElementById('edit-name').value = task.name;
        document.getElementById('edit-desc').value = task.description;
        document.getElementById('status-select-edit').value = task.statusId;
    }
    else {
        alert('Данные не выбраны')
    }
}

function closeEditForm() {
    document.getElementById('editTask').style.display = 'none';
}



function addTask() {

    const Task = {
        name: document.getElementById('add-name').value.trim(),
        description: document.getElementById('add-desc').value.trim(),
        statusId: Number(document.getElementById('status-select').value)
    }


    fetch(url, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(Task)
    })
        .then(response => response.json())
        .then(() => {
            getItems();
            document.getElementById('add-name').value = '';
            document.getElementById('add-desc').value = '';
            document.getElementById('status-select').value = 1;
            closeAddForm();

        })
        .catch(error => console.error('Unable to add item.', error));
   
}

function loadOptionAdd(id) {
    var select = document.getElementById(id)

    while (select.options.length > 0) {
        select.options.remove(0);
    }
    statusMap.forEach((value,key,map) => {
        var option = document.createElement('option');
        option.value = key;
        option.text = value;
        select.options.add(option);
    })

}


function choiceLine(id) {

    const line = document.getElementById(id);
    line.lastChild.lastChild.checked = true;
    line.style.backgroundColor = 'PaleTurquoise';
    if (chLine != line&&chLine.id!=null) resetLine(chLine.id)
    chLine = line;

    console.log(chLine.id)
}

function resetLine(id) {    
    const line = document.getElementById(id);
    line.style.backgroundColor = 'white';
}

let chLine = {
    id: null
}


