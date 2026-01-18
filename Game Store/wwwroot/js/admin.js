/* 
---------------------------------------------
Admin Panel JavaScript
--------------------------------------------- 
*/


// Select All Checkbox
document.addEventListener('DOMContentLoaded', function () {
    const selectAllCheckbox = document.getElementById('selectAll');
    const rowCheckboxes = document.querySelectorAll('.row-checkbox');
    const bulkActions = document.getElementById('bulkActions');

    if (selectAllCheckbox) {
        selectAllCheckbox.addEventListener('change', function () {
            rowCheckboxes.forEach(checkbox => {
                checkbox.checked = this.checked;
            });
            updateBulkActions();
        });
    }

    rowCheckboxes.forEach(checkbox => {
        checkbox.addEventListener('change', function () {
            updateBulkActions();

            // Update select all checkbox
            const allChecked = Array.from(rowCheckboxes).every(cb => cb.checked);
            const someChecked = Array.from(rowCheckboxes).some(cb => cb.checked);

            if (selectAllCheckbox) {
                selectAllCheckbox.checked = allChecked;
                selectAllCheckbox.indeterminate = someChecked && !allChecked;
            }
        });
    });

    function updateBulkActions() {
        const checkedCount = document.querySelectorAll('.row-checkbox:checked').length;

        if (checkedCount > 0) {
            bulkActions.style.display = 'flex';
            document.querySelector('.bulk-count').textContent = `${checkedCount} item${checkedCount > 1 ? 's' : ''} selected`;
        } else {
            bulkActions.style.display = 'none';
        }
    }

    // Deselect All Button
    const deselectBtn = document.querySelector('.deselect-all');
    if (deselectBtn) {
        deselectBtn.addEventListener('click', function () {
            rowCheckboxes.forEach(checkbox => {
                checkbox.checked = false;
            });
            if (selectAllCheckbox) {
                selectAllCheckbox.checked = false;
            }
            updateBulkActions();
        });
    }

    // Delete Selected Button
    const deleteSelectedBtn = document.querySelector('.delete-selected');
    if (deleteSelectedBtn) {
        deleteSelectedBtn.addEventListener('click', function () {
            const checkedCount = document.querySelectorAll('.row-checkbox:checked').length;
            if (confirm(`Are you sure you want to delete ${checkedCount} item(s)?`)) {
                // Add delete logic here
                alert('Items deleted successfully!');
                updateBulkActions();
            }
        });
    }


});

// Search Functionality
const searchInput = document.getElementById('searchInput');
if (searchInput) {
    searchInput.addEventListener('input', function (e) {
        const searchTerm = e.target.value.toLowerCase();
        const tableRows = document.querySelectorAll('.admin-table tbody tr');

        tableRows.forEach(row => {
            const text = row.textContent.toLowerCase();
            if (text.includes(searchTerm)) {
                row.style.display = '';
            } else {
                row.style.display = 'none';
            }
        });
    });
}

// Filter Functionality
const roleFilter = document.getElementById('roleFilter');
const genreFilter = document.getElementById('genreFilter');
const platformFilter = document.getElementById('platformFilter');

if (roleFilter) {
    roleFilter.addEventListener('change', filterTable);
}

if (genreFilter) {
    genreFilter.addEventListener('change', filterTable);
}

if (platformFilter) {
    platformFilter.addEventListener('change', filterTable);
}

function filterTable() {
    const tableRows = document.querySelectorAll('.admin-table tbody tr');

    tableRows.forEach(row => {
        let shouldShow = true;

        // Role filter
        if (roleFilter && roleFilter.value) {
            const roleBadge = row.querySelector('.role-badge');
            if (roleBadge && !roleBadge.textContent.toLowerCase().includes(roleFilter.value.toLowerCase())) {
                shouldShow = false;
            }
        }


        // Genre filter
        if (genreFilter && genreFilter.value) {
            const genreBadge = row.querySelector('.genre-badge');
            if (genreBadge && !genreBadge.textContent.toLowerCase().includes(genreFilter.value.toLowerCase())) {
                shouldShow = false;
            }
        }

        // Platform filter
        if (platformFilter && platformFilter.value) {
            const platformBadge = row.querySelector('.platform-badge');
            if (platformBadge && !platformBadge.textContent.toLowerCase().includes(platformFilter.value.toLowerCase())) {
                shouldShow = false;
            }
        }

        row.style.display = shouldShow ? '' : 'none';
    });
}

function confirmDelete(form) {
    return confirm(`Are you sure you want to delete the user?`);
}

// Image preview functionality

