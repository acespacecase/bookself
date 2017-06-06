Rails.application.routes.draw do
  resources :books
  resources :users
  devise_for :users
  root 'users#index'

end
