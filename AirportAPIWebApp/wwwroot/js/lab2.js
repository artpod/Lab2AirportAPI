const uri = 'api/Pilots';
let pilots = [];
function getCategories() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayCategories(data))
        .catch(error => console.error(' Unable to get categories.', error));
}
function addCategory() {
    const addNameTextbox = document.getElementById('add-name');
    const addInfoTextbox = document.getElementById('add-birthday');
    const pilot = {
        name: addNameTextbox.value.trim(),
        birthday: addInfoTextbox.value.trim(),
    };
    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept':'application/json',
            'Content-Type':'application/json '
        },
        body: JSON.stringify(pilot)
    })
        .then(response => response.json())
        .then(() => {
            getPilots();
            addNameTextbox.value = '';
            addInfoTextbox.value = '';
        })
        .catch(error => console.error(' Unable to add pilot.', error));
}
function deleteCategory(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
.then(() => getPilots())
.catch (error => console.error(' Unable to delete pilot.', error));
}
function displayEditForm(id) {
    const pilot = pilots.find(pilot => pilot.id == id);
    document.getElementById('edit-id').value = pilot.id;
    document.getElementById('edit-name').value = pilot.name;
    document.getElementById('edit-birthday').value = pilot.birthday;
    document.getElementById('editForm').style.display = 'block';
}
function updateCategory() {
    const pilotId = document.getElementById('edit-id').value;
    const pilot = {
        id: parseInt(pilotId, 10),
        name: document.getElementById('edit-name').value.trim(),
        birthday: document.getElementById('edit-birthday').value.trim()
    };
    fetch(`${uri}/${pilotId}`, {
        method: 'PUT',
        headers: {
            'Accept':'application/json',
            'Content-Type':'application/json'
        },
        body: JSON.stringify(pilot)
    })
        .then(() => getCategories())
        .catch(error => console.error('Unable to update pilot.', error));
    closeInput();
    return false;
}
function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}
function _displayCategories(data) {
    const tBody = document.getElementById('pilots');

    tBody.innerHTML = '';
    const button = document.createElement('button');
    data.forEach(pilot => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${pilot.id})`);
        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteCategory(${pilot.id})`);
        let tr = tBody.insertRow();
        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(pilot.name);
        td1.appendChild(textNode);
        let td2 = tr.insertCell(1);
        let textNodeInfo = document.createTextNode(pilot.birthday);
        td2.appendChild(textNodeInfo);
        let td3 = tr.insertCell(2);
        td3.appendChild(editButton);
        let td4 = tr.insertCell(3);
        td4.appendChild(deleteButton);
    });
    pilots = data;
}