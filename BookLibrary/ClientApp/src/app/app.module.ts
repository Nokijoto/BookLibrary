import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';

import { BookComponent } from './book/book.component';
import { BookDetailsComponentComponent } from './book/book-details-component/book-details-component.component';
import { AuthorComponent } from './authors/author/author.component';
import { AuthordetailsComponent } from './authors/authordetails/authordetails.component';
import { ShelfComponent } from './shelfs/shelf/shelf.component';
import { ShelfsdetailsComponent } from './shelfs/shelfsdetails/shelfsdetails.component';
import { BookFormComponent } from './book/bookOperations/book-form/book-form.component';

import { FooterComponent } from './footer/footer.component';
import { DeletebookComponent } from './book/bookOperations/deletebook/deletebook.component';
import { UpdatebookComponent } from './book/bookOperations/updatebook/updatebook.component';
import { ShelfFormComponent } from './shelfs/shelfOperations/shelf-form/shelf-form.component';
import { DeleteshelfComponent } from './shelfs/shelfOperations/deleteshelf/deleteshelf.component';
import { UpdateshelfComponent } from './shelfs/shelfOperations/updateshelf/updateshelf.component';
import { AuthorFormComponent } from './authors/author/authorOperations/author-form/author-form.component';
import { DeleteauthorComponent } from './authors/author/authorOperations/deleteauthor/deleteauthor.component';
import { UpdateauthorComponent } from './authors/author/authorOperations/updateauthor/updateauthor.component';
import { AddToShelfComponent } from './book/bookOperations/add-to-shelf/add-to-shelf.component';
import { DeleteFromShelfComponent } from './shelfs/shelfOperations/delete-from-shelf/delete-from-shelf.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    BookComponent,
    BookDetailsComponentComponent,
    AuthorComponent,
    AuthordetailsComponent,
    ShelfComponent,
    ShelfsdetailsComponent,
    BookFormComponent,
    FooterComponent,
    DeletebookComponent,
    UpdatebookComponent,
    ShelfFormComponent,
    DeleteshelfComponent,
    UpdateshelfComponent,
    AuthorFormComponent,
    DeleteauthorComponent,
    UpdateauthorComponent,
    AddToShelfComponent,
    DeleteFromShelfComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      {
        path: 'books',
        component: BookComponent,
        canActivate: [AuthorizeGuard],
      },
      {
        path: 'book/:uuid',
        component: BookDetailsComponentComponent,
        canActivate: [AuthorizeGuard],
      },
      {
        path: 'addbook',
        component: BookFormComponent,
        canActivate: [AuthorizeGuard],
      },
      {
        path: 'updatebook/:uuid',
        component: UpdatebookComponent,
        canActivate: [AuthorizeGuard],
      },
      {
        path: 'authors',
        component: AuthorComponent,
        canActivate: [AuthorizeGuard],
      },
      {
        path: 'author/:uuid',
        component: AuthordetailsComponent,
        canActivate: [AuthorizeGuard],
      },
      {
        path: 'addauthor',
        component: AuthorFormComponent,
        canActivate: [AuthorizeGuard],
      },
      {
        path: 'updateauthor/:uuid',
        component: UpdateauthorComponent,
        canActivate: [AuthorizeGuard],
      },
      {
        path: 'shelfs',
        component: ShelfComponent,
        canActivate: [AuthorizeGuard],
      },
      {
        path: 'shelf/:uuid',
        component: ShelfsdetailsComponent,
        canActivate: [AuthorizeGuard],
      },
      {
        path: 'addshelf',
        component: ShelfFormComponent,
        canActivate: [AuthorizeGuard],
      },
      {
        path: 'updateshelf/:uuid',
        component: UpdateshelfComponent,
        canActivate: [AuthorizeGuard],
      },
    ]),
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
