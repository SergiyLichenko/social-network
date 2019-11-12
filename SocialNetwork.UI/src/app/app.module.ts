import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatButtonModule } from '@angular/material/button';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatChipsModule } from '@angular/material/chips';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { Routes, RouterModule } from '@angular/router';
import { UserComponent } from './components/user/user.component';
import { MediaComponent } from "./components/media/media.component";
import { MediaService } from './services/media.service';
import { HttpClientModule } from '@angular/common/http';
import { ImageComponent } from './components/image/image.component';

const appRoutes: Routes = [
  { path: 'media', component: MediaComponent },
  { path: 'user', component: UserComponent },
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
    ImageComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    MatChipsModule,
    ReactiveFormsModule,
    FormsModule,
    MatButtonModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    MatCardModule,
    MatGridListModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [MediaService],
  bootstrap: [AppComponent]
})
export class AppModule { }
