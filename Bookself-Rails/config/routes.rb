Rails.application.routes.draw do

  devise_for :users

  get '/signup', to: 'users#new'

  devise_scope :user do
    get '/login', to: 'devise/sessions#new'
    delete '/logout', to: 'devise/sessions#destroy'
  end

  resources :users do
    resources :books, only: [:index]
  end

  resources :books


  authenticated :user do
    root to: 'books#index'
  end

  root 'users#index'


end
