import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import * as ProductActions from './product.action';
import { catchError, map, mergeMap, of } from 'rxjs';
import { ProductService } from '../../service/product/productservice';


@Injectable()
export class ProductEffects {
constructor(private actions$: Actions, private productService: ProductService) {}


loadProducts$ = createEffect(() =>
this.actions$.pipe(
ofType(ProductActions.loadProducts),
mergeMap(() =>
this.productService.getAll().pipe(
map(products => ProductActions.loadProductsSuccess({ products })),
catchError(error => of(ProductActions.loadProductsFailure({ error })))
)
)
)
);


createProduct$ = createEffect(() =>
this.actions$.pipe(
ofType(ProductActions.createProduct),
mergeMap(({ product }) =>
this.productService.create(product).pipe(
map(created => ProductActions.createProductSuccess({ product: created })),
catchError(error => of(ProductActions.createProductFailure({ error })))
)
)
)
);


updateProduct$ = createEffect(() =>
this.actions$.pipe(
ofType(ProductActions.updateProduct),
mergeMap(({ id, changes }) =>
this.productService.update(id, changes).pipe(
map(updated => ProductActions.updateProductSuccess({ product: updated })),
catchError(error => of(ProductActions.updateProductFailure({ error })))
)
)
)
);


deleteProduct$ = createEffect(() =>
this.actions$.pipe(
ofType(ProductActions.deleteProduct),
mergeMap(({ id }) =>
this.productService.delete(id).pipe(
map(() => ProductActions.deleteProductSuccess({ id })),
catchError(error => of(ProductActions.deleteProductFailure({ error })))
)
)
)
);}