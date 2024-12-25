import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { AdminLayoutRoutes } from './admin-layout.routing';

import { DashboardComponent }       from '../../pages/dashboard/dashboard.component';
import { UserComponent }            from '../../pages/user/user.component';
import { TableComponent }           from '../../pages/table/table.component';
import { TypographyComponent }      from '../../pages/typography/typography.component';
import { IconsComponent }           from '../../pages/icons/icons.component';
import { MapsComponent }            from '../../pages/maps/maps.component';
import { NotificationsComponent }   from '../../pages/notifications/notifications.component';
import { UpgradeComponent }         from '../../pages/upgrade/upgrade.component';
import { ListQuestionScreenComponent } from '../../pages/list-question-screen/list-question-screen.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
//primeng
import {DropdownModule} from 'primeng/dropdown';
import {ButtonModule} from 'primeng/button';
import { UploadFileExcelQuestionComponent } from 'app/pages/upload-file-excel-question/upload-file-excel-question.component';
import { ExamQuestionComponent } from 'app/pages/exam-question/exam-question.component';
import {InputTextModule} from 'primeng/inputtext';
import {DialogModule} from 'primeng/dialog';
import { LearningComponent } from 'app/pages/learning/learning.component';
import {AccordionModule} from 'primeng/accordion';
import { ProjectManagementComponent } from 'app/pages/project-management/project-management.component';
import { MessageService } from 'primeng/api';
import { ToastModule } from 'primeng/toast';
import { TooltipModule } from 'primeng/tooltip';

@NgModule({
  imports: [
    AccordionModule,
    DialogModule,
    DropdownModule,
    CommonModule,
    RouterModule.forChild(AdminLayoutRoutes),
    FormsModule,
    NgbModule,
    ButtonModule,
    ToastModule, // Đảm bảo ToastModule đã được import
    InputTextModule,
    TooltipModule,
  ],
  declarations: [
    ProjectManagementComponent,
    LearningComponent,
    ExamQuestionComponent,
    UploadFileExcelQuestionComponent,
    ListQuestionScreenComponent,
    DashboardComponent,
    UserComponent,
    TableComponent,
    UpgradeComponent,
    TypographyComponent,
    IconsComponent,
    MapsComponent,
    NotificationsComponent,
  ],
  providers: [MessageService], // Đảm bảo MessageService đã được cung cấp
})

export class AdminLayoutModule {}
