function register()
{
    $('a.category-button').off();
    $('a.category-button').on('click', function (event) {
        let id = $(this).find('input[name="id"]').val();
        let name = $(this).find('input[name="name"]').val()

        if ($('input[name="categoryId"]').val() == id) {
            let el = $(('#list-id-' + id)).find($('ui.list-group'));
            if (el.is(':visible'))
                el.hide();
            else
                el.show();
            return;
        }

        $.ajax({
            url: "API/GetSubcategories",
            data: {
                id: id,
                name: name
            },
            success: function (result) {
                addSubcategories(id, result);
                register();
            }
        });

        $.ajax({
            url: "API/GetArticle",
            data: {
                categoryId: id
            },
            success: function (result) {
                setArticle(id, name, result);
            }
        });

        $.ajax({
            url: "API/GetCategoryFullName",
            data: {
                id: id
            },
            success: function (result) {
                setCategoryPath(result);
            }
        });
    });

    $('#add-category').on('click', function (event) {
        $('#add-category-form').css('display', 'flex');
        $('add-category-background').show();
    });
}

function addSubcategories(id, categories) {
    let element = $(('#list-id-' + id));
    let level = element.attr('level');

    let child = element.find($('ui.list-group'));
    hideLevel(level);

    if (child.length != 0)
    {
        child.show();

    } else {
        element.append(categoriesToHtml(id, level, categories));
    }
}

function hideLevel(level)
{
    elements = $(('[level=' + level + ']')).find($('ui'));
    elements.hide();
}

function categoriesToHtml(id, level, categories)
{
    list = document.createElement('ui');
    list.classList.add('list-group');

    for (let key in categories) {

        let id = categories[key].id;
        let name = categories[key].name;

        let li = document.createElement('li');
            li.id = ('list-id-' + id);
            li.classList.add('list-group-item');
            li.classList.add('category-list-item');
            li.setAttribute('level', (parseInt(level) + 1));

        let a = document.createElement('a');
            a.classList.add('font-weight-bold');
            a.classList.add('btn');
            a.classList.add('category-button');
            a.innerHTML = ("<input type='hidden' name='id' value='" + id + "' /> " +
                "<input type='hidden' name='name' value='" + name + "' /> " +
                name);

        li.appendChild(a);
        list.appendChild(li);
    }

    return list;
}

function setArticle(id, category, article)
{
    div = $('#article');
    if (article == null)
        div.html('<span> Not found </span>');
    else
        div.html(article.body);

    $('#article-header').text(category);
    $('input[name="categoryId"]').val(id);
    $('input[name="parentId"]').val(id);
}

function setCategoryPath(html)
{
    $('#article-path').html(html);
}