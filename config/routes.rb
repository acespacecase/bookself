Rails.application.routes.draw do
  resources :users do
    resources :books, shallow: true
  end

  devise_for :users

  get '/signup', to: 'users#new'

  devise_scope :user do
    get '/login', to: 'devise/sessions#new'
    get '/logout', to: 'devise/sessions#destroy'
  end

  authenticated :user do
    root to: 'books#index'
  end

  root 'users#index'


end
