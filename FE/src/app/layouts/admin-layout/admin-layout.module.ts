import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AdminLayoutRoutes } from './admin-layout.routing';

import { DashboardComponent }       from '../../pages/dashboard/dashboard.component';
import { UserComponent }            from '../../pages/user/user.component';
import { TableComponent }           from '../../pages/table/table.component';
import { TypographyComponent }      from '../../pages/typography/typography.component';
import { IconsComponent }           from '../../pages/icons/icons.component';
import { MapsComponent }            from '../../pages/maps/maps.component';
import { NotificationsComponent }   from '../../pages/notifications/notifications.component';
import { UpgradeComponent }         from '../../pages/upgrade/upgrade.component';
import { NgxPaginationModule } from 'ngx-pagination'; // Import module phân trang

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { LophocComponent } from './QUANLY/lophoc/lophoc.component';
import { EditHistoryModalComponent } from './QUANLY/lophoc/edit-history-modal/edit-history-modal.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; // Import animations
import { ToastrModule } from 'ngx-toastr'; // Import ToastrModule

@NgModule({
  imports: [
    ReactiveFormsModule, // Thêm vào imports
    CommonModule,
    RouterModule.forChild(AdminLayoutRoutes),
    FormsModule,
    BrowserAnimationsModule, // Bắt buộc cho ngx-toastr
    ToastrModule.forRoot(), // Thiết lập ToastrModule
    NgxPaginationModule, // Thêm vào imports

    NgbModule
  ],
  declarations: [
    DashboardComponent,
    UserComponent,
    TableComponent,
    UpgradeComponent,
    TypographyComponent,
    IconsComponent,
    MapsComponent,
    NotificationsComponent,
    LophocComponent,
    EditHistoryModalComponent,
  ]
})

export class AdminLayoutModule {}
