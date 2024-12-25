import { Routes } from '@angular/router';
import { DashboardComponent } from '../../pages/dashboard/dashboard.component';
import { UserComponent } from '../../pages/user/user.component';
import { TableComponent } from '../../pages/table/table.component';
import { TypographyComponent } from '../../pages/typography/typography.component';
import { IconsComponent } from '../../pages/icons/icons.component';
import { MapsComponent } from '../../pages/maps/maps.component';
import { NotificationsComponent } from '../../pages/notifications/notifications.component';
import { UpgradeComponent } from '../../pages/upgrade/upgrade.component';
import { ListQuestionScreenComponent } from 'app/pages/list-question-screen/list-question-screen.component';
import { UploadFileExcelQuestionComponent } from 'app/pages/upload-file-excel-question/upload-file-excel-question.component';
import { ExamQuestionComponent } from 'app/pages/exam-question/exam-question.component';
import { LearningComponent } from 'app/pages/learning/learning.component';
import { ProjectManagementComponent } from 'app/pages/project-management/project-management.component';

export const AdminLayoutRoutes: Routes = [
    { path: 'dashboard',      component: DashboardComponent },
    { path: 'exam',      component: ExamQuestionComponent },
    { path: 'user',           component: UserComponent },
    { path: 'table',          component: TableComponent },
    { path: 'typography',     component: TypographyComponent },
    { path: 'icons',          component: IconsComponent },
    { path: 'maps',           component: MapsComponent },
    { path: 'notifications',  component: NotificationsComponent },
    { path: 'upgrade',        component: UpgradeComponent },
    { path: 'listquestion',        component: ListQuestionScreenComponent },
    { path: 'uploadfile',        component: UploadFileExcelQuestionComponent },
    { path: 'hocbai',        component: LearningComponent },
    { path: 'quanlyduan',        component: ProjectManagementComponent },
    
];
