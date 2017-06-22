Rails.application.routes.draw do
  resources :users do
    resources :books, shallow: true
  end

  devise_for :users
  root 'users#index'

  get '/signup', to: 'users#new'

  devise_scope :user do
    get '/login', to: 'devise/sessions#new'
    get '/logout', to: 'devise/sessions#destroy'
  end

end
