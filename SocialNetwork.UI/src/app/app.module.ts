import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatButtonModule } from '@angular/material/button';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatChipsModule } from '@angular/material/chips';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { NgxGraphModule } from '@swimlane/ngx-graph';
import { MatTableModule } from '@angular/material/table';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatSortModule } from '@angular/material/sort';
import { MatSelectModule } from '@angular/material/select';
import { MatPaginatorModule } from '@angular/material/paginator';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { Routes, RouterModule } from '@angular/router';
import { UserComponent } from './components/user/user.component';
import { MediaComponent } from "./components/media/media.component";
import { MediaService } from './services/media.service';
import { HttpClientModule } from '@angular/common/http';
import { ImageComponent } from './components/image/image.component';
import { UserResolver } from './services/resolvers/user-resolver.service';
import { DetailsComponent } from './components/details/details.component';

const appRoutes: Routes = [
  { path: 'media', component: MediaComponent },
  { path: 'user', component: UserComponent, resolve: { user: UserResolver } },
  { path: 'details', component: DetailsComponent },
  {
    path: '',
    redirectTo: '/media',
    pathMatch: 'full'
  }
];

@NgModule({
  declarations: [
    AppComponent,
    MediaComponent,
    UserComponent,
    ImageComponent,
    DetailsComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    MatCheckboxModule,
    MatTableModule,
    MatChipsModule,
    ReactiveFormsModule,
    MatSelectModule,
    FormsModule,
    MatInputModule,
    MatPaginatorModule,
    MatSortModule,
    MatFormFieldModule,
    MatButtonModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    NgxGraphModule,
    MatCardModule,
    MatGridListModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [MediaService, UserResolver],
  bootstrap: [AppComponent]
})
export class AppModule { }
