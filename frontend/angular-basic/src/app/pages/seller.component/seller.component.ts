import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import * as ProductActions from '../../store/product/product.action';
import { Observable } from 'rxjs';
import { Product } from '../../model/product';
import { selectAllProducts, selectProductLoading } from '../../store/product/product.selector';


@Component({
  selector: 'app-seller-dashboard',
  templateUrl: './seller.component.html'
})
export class SellerDashboardComponent implements OnInit {
  products$: Observable<Product[]>;
  loading$: Observable<boolean>;


  selectedProduct: Product | null = null; // for editing


  constructor(private store: Store) {
    this.products$ = this.store.select(selectAllProducts);
    this.loading$ = this.store.select(selectProductLoading);
  }


  ngOnInit() {
    // load seller products from server
    this.store.dispatch(ProductActions.loadProducts());
  }


  onCreate(productData: Product) {
    this.store.dispatch(ProductActions.createProduct({ product: productData }));
  }


  onEdit(product: Product) {
    this.selectedProduct = product;
  }


  onUpdate(id: string, changes: Product) {
    this.store.dispatch(ProductActions.updateProduct({ id, changes }));
    this.selectedProduct = null;
  }


  onDelete(id: string) {
    if (!confirm('Delete this product?')) return;
    this.store.dispatch(ProductActions.deleteProduct({ id }));
  }


  onCancelEdit() {
    this.selectedProduct = null;
  }
}