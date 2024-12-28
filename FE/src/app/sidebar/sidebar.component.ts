import { Component, OnInit } from '@angular/core';


export interface RouteInfo {
    path: string;
    title: string;
    icon: string;
    class: string;
}

export const ROUTES: RouteInfo[] = [
    { path: '/dashboard',     title: 'Thống kê',         icon:'nc-bank',       class: '' },
   { path: '/user',          title: 'Thông tin cá nhân',      icon:'nc-single-02',  class: '' },
    { path: '/listquestion',     title: 'Quản lý lớp học',         icon:'nc-hat-3',       class: '' },
    { path: '/quanlyduan',     title: 'Quản lý bài học',         icon:'nc-paper',       class: '' },
    { path: '/quanlycauhoi',     title: 'Quản lý câu hỏi',         icon:'nc-app',       class: '' },
    // { path: '/quanly',     title: 'Quản lý tài nguyên',         icon:'nc-app',       class: '' },
    // { path: '/uploadfile',     title: 'Upload file excel',         icon:'nc-send',       class: '' },
    // { path: '/exam',     title: 'Kiểm tra kiến thức',         icon:'nc-briefcase-24',       class: '' },
    { path: '/chamdiem',     title: 'Chấm điểm',         icon:'nc-badge',       class: '' },
    { path: '/lambai',     title: 'làm bài thử',         icon:'nc-button-play',       class: '' },
    // { path: '/hocbai',     title: 'Học bài',         icon:'nc-glasses-2',       class: '' },
    

    // { path: '/icons',         title: 'Icons',             icon:'nc-diamond',    class: '' },
    // { path: '/maps',          title: 'Maps',              icon:'nc-pin-3',      class: '' },
    // { path: '/notifications', title: 'Notifications',     icon:'nc-bell-55',    class: '' },

    // { path: '/table',         title: 'Table List',        icon:'nc-tile-56',    class: '' },
    // { path: '/typography',    title: 'Typography',        icon:'nc-caps-small', class: '' }
];

@Component({
    moduleId: module.id,
    selector: 'sidebar-cmp',
    templateUrl: 'sidebar.component.html',
})

export class SidebarComponent implements OnInit {
    public menuItems: any[];
    ngOnInit() {
        this.menuItems = ROUTES.filter(menuItem => menuItem);
    }
}
