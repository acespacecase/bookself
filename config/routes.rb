Rails.application.routes.draw do
  resources :users do
    resources :books, shallow: true
  end

  resources :books do
    resources :tags, shallow: true
  end

  devise_for :users
  root 'users#index'
  get '/signup', to: 'users#new'


end
