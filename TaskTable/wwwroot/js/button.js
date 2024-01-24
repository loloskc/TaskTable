

function showAddForm() {
    document.getElementById('addTask').style.display = 'block';
    loadOptionAdd();
}

function closeAddForm() {
    document.getElementById('addTask').style.display = 'none';
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

function loadOptionAdd() {
    var select = document.getElementById('status-select')

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
    let flag = false;
function choiceLine() {
    

}