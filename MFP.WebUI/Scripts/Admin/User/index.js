
layui.use(['table','layer'], function () {
    var table = layui.table;

    table.render({
        elem: '#userList'
        , url: '/admin/user/getuser'
        ,request: {
            pageName: 'pageIndex' //页码的参数名称，默认：page
            ,limitName: 'pageSize' //每页数据量的参数名，默认：limit
        }
        ,response: {
            statusName: 'Status' //数据状态的字段名称，默认：code
            ,statusCode: 200 //成功的状态码，默认：0
            ,msgName: 'Msg' //状态信息的字段名称，默认：msg
            ,countName: 'Total' //数据总数的字段名称，默认：count
            ,dataName: 'Data' //数据列表的字段名称，默认：data
        }
        , height: 'full-112'
        , cellMinWidth: 80 //全局定义常规单元格的最小宽度，layui 2.2.1 新增
        , cols: [[
            { field: 'UserID', title: 'ID', sort: true }
            , { field: 'Name', title: '用户名' } //width 支持：数字、百分比和不填写。你还可以通过 minWidth 参数局部定义当前单元格的最小宽度，layui 2.2.1 新增
            , { field: 'Age', title: '年龄' }
            , { field: 'Email', title: '邮箱' }
            , { fixed: 'right', title: '操作', align: 'center', toolbar: '#girdToolbar' }
        ]]
        , page: { //支持传入 laypage 组件的所有参数（某些参数除外，如：jump/elem） - 详见文档
            layout: ['limit', 'count', 'prev', 'page', 'next', 'skip'] //自定义分页布局
            , groups: 5 //只显示 1 个连续页码
            , first: true //不显示首页
            , last: true //不显示尾页

        }
        , id: 'userList'
    });

    table.on('tool(userlist)', function (obj) {
        var data = obj.data;
        if (obj.event === 'detail') {
            layer.msg('ID：' + data.UserID + ' 的查看操作');
        } else if (obj.event === 'delete') {
            
            layer.confirm('真的删除行么', function (index) {

                $.ajax({
                    url:url_delUser,
                    type: 'post',
                    data: { userID: encodeURIComponent("哈哈") },
                    dataType: 'json',
                    success:function(data,textStatus,jqXhr) {
                        layer.msg('删除成功');
                        obj.del();
                        layer.close(index);
                    },
                    error:function(XMLRequest,textStatus,errorThrown) {
                        layer.msg('删除失败');
                    }
                });
            });
        } else if (obj.event === 'edit') {
            var layId = 'tab-edituser-' + data.UserID;
            var title = '编辑用户(' + data.Name + ')';
            var url = url_editUser + '?UserID=' + data.UserID;
            common.openNewTab(layId, title, url);
        }
    });

    var $ = layui.$;
    var active = {
        search: function () {
            var keyword = $("#input-keyword").val();
            if (keyword == '') {
                return;
            }
            table.reload('userList', {
                page: {
                    curr: 1 //重新从第 1 页开始
                }
                , where: {
                    keyWord: keyword
                }
            });
        },
        reset: function () {
            $("#input-keyword").val('');
            table.reload('userList', {
                page: {
                    curr: 1 //重新从第 1 页开始
                }
                ,where: {
                    keyWord: ''
                }
            });
        },
        add: function () {
            common.openNewTab('tab-adduser', '新增用户', url_addUser);
        }
        
    }


    $("#toolbar .layui-btn").click(function () {
        var type = $(this).data('type');
        active[type] ? active[type].call(this) : '';
    });
});





